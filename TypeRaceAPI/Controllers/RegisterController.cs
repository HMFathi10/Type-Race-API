using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using TypeRaceAPI.Core.Models;

namespace TypeRaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public RegisterController(IConfiguration configuration, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        private bool IsAuthenticatedUser()
        {
            // Check if the user is logged in.
            return HttpContext.User.Identity?.IsAuthenticated ?? false;
        }
        private IActionResult UserLoggedIn()
        {
            return BadRequest(new { message = "Already logged in you should log out first." });
        }
        private IActionResult SuccessLogin() 
        {
            return Ok();
        }
        private async Task<bool> EmailExists(string email)
        {
            if (await userManager.FindByEmailAsync(email) != null)
            {
                return true;
            }
            return false;
        }
        private IActionResult ExistedEmail()
        {
            return BadRequest(new { message = "This email already exists." });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserModel login)
        {
            // 1) Declare and Define IActionResult with default response Unauthorized.
            IActionResult response = Unauthorized();

            // 2) Check if the user is logged in.
            if (IsAuthenticatedUser())
            {
                return UserLoggedIn();
            }

            // 3) Declare and Define user with the existing user.
            var user = await AuthenticateUser(login);

            // 4) Check if the user input the right email and password.
            if (user != null)
            {
                // 4) Check if the user enterd the right email and password.
                var result = await signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, false);
                
                if (result.Succeeded)
                {
                    response = SuccessLogin();
                }
            }

            // 6) Return the response.
            return response;
        }


        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody]SignUpModel model)
        {
            // 1) Declare and define the respose as Unauthorized.
            IActionResult response = Unauthorized();

            // 2) Check if the user is logged in.
            if (IsAuthenticatedUser())
            {
                return UserLoggedIn();
            }

            // 2) Check if the Input data is valid.
            if (ModelState.IsValid)
            {
                // 4) Check if the email is exists.
                if (await EmailExists(model.Email))
                {
                    return ExistedEmail();
                }

                // 5) Define a new User with input data.
                var user = new IdentityUser { UserName = model.Username, Email = model.Email };

                // 6) Save the user into database.
                var result = await userManager.CreateAsync(user, model.Password);

                // 7) Check if the user is stored.
                if (result.Succeeded)
                {
                    // 8) Try to login in with new user.
                    await signInManager.SignInAsync(user, isPersistent: false);
                    response = SuccessLogin();
                }
            }
            // 9) Return the response.
            return response;
        }
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }
        private async Task<IdentityUser?> AuthenticateUser(UserModel login)
        {
            // Find User if exist.
            var user = await userManager.FindByEmailAsync(login.Email);
            if (user != null && (await userManager.CheckPasswordAsync(user, login.Password)))
            {
                return user;
            }
            return null;
        }
    }
}
