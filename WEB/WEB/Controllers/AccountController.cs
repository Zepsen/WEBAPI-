using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WEB.Infrastructure;
using WEB.Models;

namespace WEB.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUsersService _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(
            IUsersService service,
            UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
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
                await _service.InsertAsync(UserDto.Default(user.Id, model.UserName));

                var token = CreateToken(user, new List<string> {RoleHelper.DefaultRole});

                return Ok(new
                {
                    access_token = token,
                    username = user.Email
                });
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
                var user = await _userManager.FindByEmailAsync(model.Email);
                var result = await _userManager.CheckPasswordAsync(user, model.Password);

                if (result)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    var token = CreateToken(user, roles);
                    return Ok(new { token = token, returnUrl = model.ReturnUrl, roles = roles});
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
            throw new NotImplementedException();
            return Ok(new { returnUrl = model.ReturnUrl });
        }


        private string CreateToken(ApplicationUser user, IList<string> roles)
        {
            var identity = GetIdentity(user.Email, roles);
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));


            return new JwtSecurityTokenHandler().WriteToken(jwt);

        }

        private ClaimsIdentity GetIdentity(string email, IList<string> roles)
        {
            var claims = new List<Claim> { new Claim(ClaimsIdentity.DefaultNameClaimType, email) };
            claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));
            return new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}