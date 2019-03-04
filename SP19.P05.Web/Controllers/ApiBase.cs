using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SP19.P05.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public   class ApiBase : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new[] { "value1", "value2" };
        }
    }

}
