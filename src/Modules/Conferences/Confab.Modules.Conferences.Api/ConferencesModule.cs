using Confab.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Confab.Modules.Conferences.Api
{
    public class ConferencesModule: IModule
    {
        public const string BasePath = "conferences-module";
        public string Name { get; } = "Conferences";
        public string Path => BasePath;
        
        public void Register(IServiceCollection services)
        {
            throw new System.NotImplementedException();
        }

        public void Use(IApplicationBuilder app)
        {
            throw new System.NotImplementedException();
        }
    }
}