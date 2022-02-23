using Microsoft.AspNetCore.Authorization;

namespace Confab.Modules.Tickets.Api.Controllers
{
    [Authorize(Policy = Policy)]
    internal class TicketsController : BaseController
    {
        private const string Policy = "tickets";

        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
    }
}