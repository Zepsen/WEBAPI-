using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using BLL.Infrastructure;
using BLL.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WEB.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var roles = await _roleManager.Roles.Select(i => i.Name).ToListAsync();
            return Ok(roles);
        }
        
        [HttpPost]
        [Authorize(Roles = RoleHelper.Admin)]
        public async Task<IActionResult> Post([FromQuery]string role)
        {
            if (role.IsNotNullOrEmpty())
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                    return Ok();
                }
                else ModelState.AddModelError("role", "This role is already exist");

            } else ModelState.AddModelError("role", "role is empty");

            return ValidationProblem(ModelState);
        }

        [HttpPut]
        [Authorize(Roles = RoleHelper.Admin)]
        public async Task<IActionResult> Put([FromQuery]string oldRole, [FromQuery]string newRole)
        {
            if (newRole.IsNotNullOrEmpty() || oldRole.IsNotNullOrEmpty())
            {
                if (await _roleManager.RoleExistsAsync(oldRole))
                {
                    var identityRole = await _roleManager.Roles.FirstAsync(i => i.Name == oldRole);
                    identityRole.Name = newRole;
                    await _roleManager.UpdateAsync(identityRole);
                    return Ok();
                }

                ModelState.AddModelError("role", "Role is not exist");

            } else ModelState.AddModelError("role", "role is empty");

            return ValidationProblem(ModelState);
        }

        [HttpDelete]
        [Authorize(Roles = RoleHelper.Admin)]
        public async Task<IActionResult> Delete([FromQuery]string role)
        {
            if (role.IsNotNullOrEmpty())
            {
                if (await _roleManager.RoleExistsAsync(role))
                {
                    var identityRole = await _roleManager.Roles.FirstAsync(i => i.Name == role);
                    await _roleManager.DeleteAsync(identityRole);
                    return Ok();
                }

                ModelState.AddModelError("role", "Role is not exist");
            } else ModelState.AddModelError("role", "role is empty");

            return ValidationProblem(ModelState);
        }
    }
}
