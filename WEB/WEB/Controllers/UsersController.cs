using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Infrastructure;
using BLL.Infrastructure.Filters;
using BLL.Interfaces;
using HashidsNet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json.Linq;
using WEB.Infrastructure.Automapper;

namespace WEB.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersService _service;
        private readonly IHttpContextAccessor _accessor;
        private readonly Hashids _hash;

        public UsersController(
            IUsersService service,
            IHttpContextAccessor accessor)
        {
            _service = service;
            _accessor = accessor;
            _hash = new Hashids(nameof(UsersDto));
        }

        // GET api/[controller]
        [HttpGet]
        public async Task<IActionResult> Get(FilterBase filter)
        {
            return Ok(await _service.GetAsync(filter));
        }

        // GET api/[controller]/{id}
        [HttpGet("{id}")]
        public async Task<UsersDto> Get([FromRoute]string id)
        {
            return await _service.GetByIdAsync(_hash.Decode(id).FirstOr(0));
        }

        // POST api/[controller]
        [HttpPost]
        public async Task Post([FromBody]UsersDto user)
        {
            await _service.InsertAsync(user);
        }

        // PUT api/[controller]/{id}
        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody]UsersDto user)
        {
            await _service.UpdateAsync(_hash.Decode(id).FirstOr(0), user);
        }

        // PATCHED api/[controller]/{id}
        [HttpPatch("{id}")]
        public async Task Patch(string id, [FromBody]CompaniesDto dto)
        {
            if (_accessor.HttpContext.Request.Body.CanSeek)
            {
                _accessor.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);
                var data = await new StreamReader(_accessor.HttpContext.Request.Body).ReadToEndAsync();
                var json = JObject.Parse(data).ToObject<Dictionary<string, object>>();

                await _service.UpdateSpecificAsync(_hash.Decode(id).FirstOr(0), json);
            }
        }

        // DELETE api/[controller]/{id}
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute]int id)
        {
            await _service.DeleteAsync(id);
        }
    }
}
