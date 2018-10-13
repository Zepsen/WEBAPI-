using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Infrastructure.Filters;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WEB.Infrastructure.Attributes;

namespace WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _service;
        

        public UsersController(
            IUsersService service
            )
        {
            _service = service;
        }

        // GET api/[controller]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]FilterBase filter)
        {
            return Ok(await _service.GetAsync(filter));
        }

        // GET api/[controller]/{id}
        [DecodeHashId]
        [HttpGet("{id}")]
        public async Task<UserDto> Get([FromQuery]int id)
        {
            return await _service.GetByIdAsync(id);
        }

        // POST api/[controller]
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task Post([FromBody]UserDto user)
        {
            await _service.InsertAsync(user);
        }

        // PUT api/[controller]/{id}
        [HttpPut("{id}")]
        [DecodeHashId]
        public async Task Put([FromQuery]int id, [FromBody]UserDto user)
        {
            await _service.UpdateAsync(id, user);
        }

        // PATCHED api/[controller]/{id}
        [HttpPatch("{id}")]
        [DecodeHashId]
        [DecodeJson]
        public async Task Patch([FromQuery]int id, Dictionary<string, object> json)
        {
            await _service.UpdateSpecificAsync(id, json);
        }

        // DELETE api/[controller]/{id}
        [HttpDelete("{id}")]
        [DecodeHashId]
        [ProducesResponseType(200)]
        public async Task Delete([FromQuery]int id)
        {
            await _service.DeleteAsync(id);
        }
    }
}
