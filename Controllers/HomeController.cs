using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingManagement.Models;

namespace TrainingManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {
        }
        //api/home
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = nameof(RoleTypes.User))]
        public IActionResult Health()
        {
            return Ok("Api is fine");
        }

        //api/home/admin
        [HttpGet("admin")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = nameof(RoleTypes.Admin))]
        public IActionResult AdminRoute()
        {
            return Ok("Admin route");
        }

        //api/home/user
        [HttpGet("user")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = nameof(RoleTypes.User))]
        public IActionResult UserRoute()
        {
            return Ok("User route");
        }
    }
}
