using System.Runtime.CompilerServices;
using Confab.Modules.Tickets.Core.DAL;
using Confab.Modules.Tickets.Core.DAL.Repositories;
using Confab.Modules.Tickets.Core.Repositories;
using Confab.Modules.Tickets.Core.Services;
using Confab.Shared.Infrastructure.Postgres;
using Microsoft.Extensions.DependencyInjection;

[assembly:InternalsVisibleTo("Confab.Modules.Tickets.Api")]
namespace Confab.Modules.Tickets.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
            => services
                .AddScoped<ITicketService, TicketsService>()
                .AddScoped<IConferenceRepository, ConferenceRepository>()
                .AddScoped<ITicketRepository, TicketRepository>()
                .AddScoped<ITicketSaleRepository, TicketSaleRepository>()
                .AddPostgres<TicketsDbContext>();
    }
}