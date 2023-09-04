using Microsoft.AspNetCore.Mvc;
using DummyApi.Attributes;

namespace DummyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpGet("public")]
        public IActionResult PublicEndpoint()
        {
            return Ok("Public endpoint");
        }

        [HttpGet("private")]
        [Authorize]
        public IActionResult PrivateEndpoint()
        {
            return Ok("Private endpoint");
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminEndpoint()
        {
            return Ok("Admin endpoint");
        }
    }
}
