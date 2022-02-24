using System;
using System.Threading.Tasks;

namespace Confab.Modules.Tickets.Core.Services
{
    internal interface ITicketService
    {
        Task<object> GetForUserAsync(Guid identityId);
    }
}