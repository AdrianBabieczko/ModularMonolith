using System;
using System.Threading.Tasks;

namespace Confab.Modules.Tickets.Core.Services
{
    public class TicketsService : ITicketService
    {
        public Task<object> GetForUserAsync(Guid identityId)
        {
            throw new NotImplementedException();
        }
    }
}