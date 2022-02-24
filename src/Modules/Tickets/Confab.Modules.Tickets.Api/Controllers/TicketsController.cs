using System.Collections.Generic;
using System.Threading.Tasks;
using Confab.Modules.Tickets.Core.DTO;
using Confab.Modules.Tickets.Core.Services;
using Confab.Shared.Abstractions.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Confab.Modules.Tickets.Api.Controllers
{
    [Authorize]
    internal class TicketsController : BaseController
    {
        private readonly ITicketService _ticketService;
        private readonly IContext _context;

        public TicketsController(ITicketService ticketService, IContext context)
        {
            _ticketService = ticketService;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<IReadOnlyList<TicketDto>>> Get()
            => Ok(await _ticketService.GetForUserAsync(_context.Identity.Id));
    }
}