using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Confab.Modules.Conferences.Api;
using Confab.Shared.Abstractions.Modules;
using Confab.Shared.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Confab.Bootstrapper
{
    public class Startup
    {
        private readonly IList<Assembly> _assemblies;
        private readonly IList<IModule> _modules;

        public Startup()
        {
            _assemblies = ModuleLoader.LoadAssemblies();
            _modules = ModuleLoader.LoadModules(_assemblies);
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        { 
            app.UseInfrastructure();
        }
    }
}
