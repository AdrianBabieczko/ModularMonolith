using System.Runtime.CompilerServices;
using Confab.Modules.Tickets.Core.Services;
using Microsoft.Extensions.DependencyInjection;

[assembly:InternalsVisibleTo("Confab.Modules.Tickets.Api")]
namespace Confab.Modules.Tickets.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
            => services
                .AddScoped<ITicketService, TicketsService>();
    }
}