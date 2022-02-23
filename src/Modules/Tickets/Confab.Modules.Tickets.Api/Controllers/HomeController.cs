using Microsoft.AspNetCore.Mvc;

namespace Confab.Modules.Tickets.Api.Controllers
{
    internal class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult<string> Get() => "Tickets API";
    }
}