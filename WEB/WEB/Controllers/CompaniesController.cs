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
    public class CompaniesController : Controller
    {
        private readonly ICompaniesService _service;
       

        public CompaniesController(
            ICompaniesService service)
        {
            _service = service;
        }

        // GET api/[controller]
        [HttpGet]
        public async Task<IActionResult> Get(FilterBase filterBase)
        {
            return Ok(await _service.GetAsync(filterBase));
        }

        // GET api/[controller]/{id}
        [HttpGet("{id}")]
        [DecodeHashId]
        public async Task<CompanyDto> Get(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        // POST api/[controller]
        [HttpPost]
        public async Task Post([FromBody]CompanyDto dto)
        {
            await _service.InsertAsync(dto);
        }

        // PUT api/[controller]/{id}
        [HttpPut("{id}")]
        [DecodeHashId]
        public async Task Put(int id, [FromBody]CompanyDto dto)
        {
            await _service.UpdateAsync(id, dto);
        }

        // PATCHED api/[controller]/{id}
        [HttpPatch("{id}")]
        [DecodeHashId]
        [DecodeJson]
        public async Task Patch(int id, Dictionary<string, object> json)
        {
            await _service.UpdateSpecificAsync(id, json);
        }
        
        // DELETE api/[controller]/{id}
        [HttpDelete("{id}")]
        [DecodeHashId]
        public async Task Delete(int id)
        {
            await _service.DeleteAsync(id);
        }
    }
}