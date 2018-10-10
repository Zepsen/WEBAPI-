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
    [Route("api/[controller]")]
    //[ApiController]
    public class AccountController : Controller
    {
        private readonly IUsersService _service;
        private readonly UserManager<UserIdentity> _userManager;
        private readonly SignInManager<UserIdentity> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            IUsersService service,
            UserManager<UserIdentity> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<UserIdentity> signInManager)
        {
            _service = service;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        // POST api/[controller]
        /// <summary>
        /// Registration
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
//        [Route("api/register")]
        public async Task<IActionResult> Post([FromBody]RegisterModel model)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var user = new UserIdentity { Email = model.Email, UserName = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, RoleHelper.DefaultRole);
                await _service.InsertAsync(new UserDto(model.UserName));
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
    }
}