using Confab.Modules.Conferences.Api;
using Confab.Shared.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Confab.Bootstrapper
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure();
            services.AddConferences();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {   
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseInfrastructure();
        }
    }
}
