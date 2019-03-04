using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SP19.P05.Web.Features.Authorization;

namespace SP19.P05.Web.Controllers
{
    [Route("[controller]")]
    public class DemoController : Controller
    {
        [HttpGet]
        public IActionResult Customer()
        {
            return View(User);
        }
    }
}
