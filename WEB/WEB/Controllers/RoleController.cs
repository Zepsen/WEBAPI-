using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using BLL.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WEB.Models;

namespace WEB.Controllers
{
    //[Authorize]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        [Route("api/[controller]/all")]
        public async Task<IActionResult> Get()
        {
            var roles = await _roleManager.Roles.Select(i => i.Name).ToListAsync();
            return Ok(roles);
        }


        [HttpPost]
        //[Authorize(Roles = RoleHelper.Admin)]
        [Route("api/[controller]/add")]
        public async Task<IActionResult> Post([FromBody]RoleModel model)
        {
            if (ModelState.IsValid)
            {
                if (!await _roleManager.RoleExistsAsync(model.Role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(model.Role));
                    return Ok();
                }
                else ModelState.AddModelError("role", "This role is already exist");

            } else ModelState.AddModelError("role", "role is empty");

            return ValidationProblem(ModelState);
        }

        [HttpPut]
        [Authorize(Roles = RoleHelper.Admin)]
        [Route("api/[controller]/update")]
        public async Task<IActionResult> Put([FromBody]EditRoleModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _roleManager.RoleExistsAsync(model.OldRole))
                {
                    var identityRole = await _roleManager.Roles.FirstAsync(i => i.Name == model.OldRole);
                    identityRole.Name = model.NewRole;
                    await _roleManager.UpdateAsync(identityRole);
                    return Ok();
                }

                ModelState.AddModelError("role", "Role is not exist");

            } else ModelState.AddModelError("model", "Model is not valid");

            return ValidationProblem(ModelState);
        }

        [HttpDelete]
        [Authorize(Roles = RoleHelper.Admin)]
        [Route("api/[controller]/delete")]
        public async Task<IActionResult> Delete([FromBody]RoleModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _roleManager.RoleExistsAsync(model.Role))
                {
                    var identityRole = await _roleManager.Roles.FirstAsync(i => i.Name == model.Role);
                    await _roleManager.DeleteAsync(identityRole);
                    return Ok();
                }

                ModelState.AddModelError("role", "Role is not exist");
            } else ModelState.AddModelError("role", "role is empty");

            return ValidationProblem(ModelState);
        }
    }
}
