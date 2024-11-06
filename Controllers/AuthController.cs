using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrainingManagement.Models;
using System.Linq;
using TrainingManagement.Services;
using Microsoft.EntityFrameworkCore;

namespace TrainingManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JwtService _jwtService;

        public AuthController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            SignInManager<IdentityUser> signInManager,
            JwtService jwtService) // Inject JwtService here
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        // auth/register/trainer
        [HttpPost("register/trainer")]
        public async Task<IActionResult> RegisterTrainer([FromBody] RegisterModel model)
        {
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Trainer");
                var token = _jwtService.GenerateToken(model.Email, "Trainer");
                return Ok(new { Token = token });
            }

            return BadRequest(result.Errors);
        }

        // auth/register/student
        [HttpPost("register/student")]
        public async Task<IActionResult> RegisterStudent([FromBody] RegisterModel model)
        {
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Student");
                var token = _jwtService.GenerateToken(model.Email, "Student");
                return Ok(new { Token = token });
            }

            return BadRequest(result.Errors);
        }

        // auth/login/trainer
        [HttpPost("login/trainer")]
        public async Task<IActionResult> LoginTrainer([FromBody] LoginModel userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password,
                isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(userInfo.Email);
                if (await _userManager.IsInRoleAsync(user, "Trainer"))
                {
                    var token = _jwtService.GenerateToken(userInfo.Email, "Trainer");
                    return Ok(new { Token = token });
                }
                return Unauthorized("User is not a trainer.");
            }
            return BadRequest("Email or password invalid!");
        }

        //auth/login/student
       [HttpPost("login/student")]
        public async Task<IActionResult> LoginStudent([FromBody] LoginModel userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password,
                isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(userInfo.Email);
                if (await _userManager.IsInRoleAsync(user, "Student"))
                {
                    var token = _jwtService.GenerateToken(userInfo.Email, "Student");
                    return Ok(new { Token = token });
                }
                return Unauthorized("User is not a student.");
            }
            return BadRequest("Email or password invalid!");
        }

    }
}
