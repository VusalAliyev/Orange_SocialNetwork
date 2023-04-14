using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Domain.DTOs;
using SocialNetwork.Domain.Entites;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return BadRequest("invalid email or password");
            }
            SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, true);

            if (signInResult.IsLockedOut)
            {
                return BadRequest("that email account has been blocked");
            }
            if (!signInResult.Succeeded)
            {
                return BadRequest("invalid email or password");
            }


            return Ok("Logged in");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            AppUser user = new AppUser
            {
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                UserName = registerDto.UserName
            };

            await _userManager.CreateAsync(user, registerDto.Password);

            await _userManager.AddToRoleAsync(user, "User");
            await _signInManager.SignInAsync(user, false);

            return Ok(user);
        }
        [HttpPost]

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return NoContent();
        }


        #region CreateRole
        //[HttpPost]
        //public async Task CreateRole()
        //{
        //    if (!await _roleManager.RoleExistsAsync("Admin"))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    }

        //    if (!await _roleManager.RoleExistsAsync("User"))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
        //    }
        //}
        #endregion
    }
}
