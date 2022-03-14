using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Confab.Modules.Tickets.Core.DTO;

namespace Confab.Modules.Tickets.Core.Services
{
    internal interface ITicketService
    {
        Task<IEnumerable<TicketDto>> GetForUserAsync(Guid userId);
        Task PurchaseAsync(Guid conferenceId, Guid userId);
    }
}