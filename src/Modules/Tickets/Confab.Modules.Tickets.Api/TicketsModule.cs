using Confab.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Confab.Modules.Tickets.Api
{
    public class TicketsModule: IModule
    {
        public const string BasePath = "tickets-module";
        public string Name { get; } = "Tickets";
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