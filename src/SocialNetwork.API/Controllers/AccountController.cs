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
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            AppUser user= await _userManager.FindByEmailAsync(loginDto.Email);
            if (user==null)
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
                FullName=registerDto.FullName,
                Email=registerDto.Email,
                UserName=registerDto.UserName
            };

            await _userManager.CreateAsync(user,registerDto.Password);

            await _signInManager.SignInAsync(user, true);

            return Ok(user);
        }
        [HttpPost]    
        
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return NoContent();
        }
    }
}
