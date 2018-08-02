using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Infrastructure.Filters;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WEB.Controllers
{
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        private readonly ICompaniesService _service;
        private readonly IHttpContextAccessor _accessor;
        

        public CompaniesController(
            ICompaniesService service,
            IHttpContextAccessor accessor
            )
        {
            _service = service;
            _accessor = accessor;
        }

        // GET api/[controller]
        [HttpGet]
        public async Task<IActionResult> Get(FilterBase filterBase)
        {
            return Ok(await _service.GetAsync(filterBase));
        }

        // GET api/[controller]/{id}
        [HttpGet("{id}")]
        public async Task<CompaniesDto> Get([FromRoute]int id)
        {
            return await _service.GetByIdAsync(id);
        }

        // POST api/[controller]
        [HttpPost]
        public async Task Post([FromBody]CompaniesDto dto)
        {
            await _service.InsertAsync(dto);
        }

        // PUT api/[controller]/{id}
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]CompaniesDto dto)
        {
            if (_accessor.HttpContext.Request.Body.CanSeek)
            {
                _accessor.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);
                var data = await new StreamReader(_accessor.HttpContext.Request.Body).ReadToEndAsync();
                var json = JObject.Parse(data).ToObject<Dictionary<string, object>>();

                await _service.UpdateSpecificAsync(id, json);
            }
        }

        [HttpPatch("{id}")]
        public async Task Patch(int id, [FromBody]CompaniesDto dto)
        {
             await _service.UpdateAsync(id, dto);
        }
        
        // DELETE api/[controller]/{id}
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute]int id)
        {
            await _service.DeleteAsync(id);
        }
    }
}