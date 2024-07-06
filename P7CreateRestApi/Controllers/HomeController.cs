using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Authorize(policy: "User")]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet]
        [Route("Admin")]
        [Authorize(policy: "Admin")]
        public IActionResult Admin()
        {
            return Ok();
        }
    }
}