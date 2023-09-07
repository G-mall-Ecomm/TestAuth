using Microsoft.AspNetCore.Mvc;
using DummyApi.Attributes;
using Microsoft.AspNetCore.Authorization;  // Make sure this is included

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

        // Apply the Authorize attribute here
        [HttpGet("private")]
        [Authorize]  // Secure this endpoint
        public IActionResult PrivateEndpoint()
        {
            return Ok("Private endpoint");
        }

        // Apply the Authorize attribute with role
        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]  // Secure this endpoint and only allow Admin role
        public IActionResult AdminEndpoint()
        {
            return Ok("Admin endpoint");
        }
    }
}
