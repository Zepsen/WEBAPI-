using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUsersService _service;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            IUsersService service,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _service = service;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        /// <summary>
        /// Registration
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/[controller]/register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var user = new ApplicationUser { Email = model.Email, UserName = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, RoleHelper.DefaultRole);
                await _service.InsertAsync(new UserDto(user.Id, model.UserName));
                await _signInManager.SignInAsync(user, false);
                return Ok();
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return ValidationProblem(ModelState);
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/[controller]/login")]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager
                    .PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return Ok(new { returnUrl = model.ReturnUrl });
                    //if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    //{
                    //    return Ok(model.ReturnUrl);
                    //}
                    //else
                    //{
                    //    return Forbid();
                    //}
                }
                else
                {
                    ModelState.AddModelError("", "Wrong login or password");
                }
            }

            return ValidationProblem(ModelState);
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/[controller]/logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutModel model)
        {
            await _signInManager.SignOutAsync();
            return Ok(new { returnUrl = model.ReturnUrl });
        }
    }
}