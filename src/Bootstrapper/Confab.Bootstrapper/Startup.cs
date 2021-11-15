using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Confab.Shared.Abstractions.Modules;
using Confab.Shared.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Confab.Bootstrapper
{
    public class Startup
    {
        private readonly IList<Assembly> _assemblies;
        private readonly IList<IModule> _modules;

        public Startup(IConfiguration configuration)
        {
            _assemblies = ModuleLoader.LoadAssemblies(configuration);
            _modules = ModuleLoader.LoadModules(_assemblies);
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure();

            foreach (var module in _modules)
            {
                module.Register(services);
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        { 
            app.UseInfrastructure();

            foreach (var module in _modules)
            {
                module.Use(app);
            }

            logger.LogInformation($"Modules: {string.Join(", ", _modules.Select(x => x.Name))}");
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", context => context.Response.WriteAsync("Confab API!"));
            });
            
            _assemblies.Clear();
            _modules.Clear();
        }
    }
}
