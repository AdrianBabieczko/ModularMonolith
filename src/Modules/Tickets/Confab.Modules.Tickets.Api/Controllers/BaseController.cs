using Microsoft.AspNetCore.Mvc;

namespace Confab.Modules.Tickets.Api.Controllers
{
    [ApiController]
    [Route(TicketsModule.BasePath + "/[controller]")]
    internal class BaseController: ControllerBase
    {
        
    }
}