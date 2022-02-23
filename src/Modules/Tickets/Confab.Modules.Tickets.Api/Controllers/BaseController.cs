using Microsoft.AspNetCore.Mvc;

namespace Confab.Modules.Tickets.Api.Controllers
{
    [ApiController]
    [Route(TicketsModule.BasePath + "/[controller]")]
    internal class BaseController: ControllerBase
    {
        protected ActionResult<T> OkOrNotFount<T>(T model)
        {
            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }
    }
}