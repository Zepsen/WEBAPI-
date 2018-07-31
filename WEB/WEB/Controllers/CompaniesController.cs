using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IEnumerable<Companies>> Get()
        {
            return await _service.GetAsync();
        }

        // GET api/[controller]/{id}
        [HttpGet("{id}")]
        public async Task<Companies> Get([FromRoute]int id)
        {
            return await _service.GetByIdAsync(id);
        }

        // POST api/[controller]
        [HttpPost]
        public async Task Post([FromBody]Companies user)
        {
            await _service.InsertAsync(user);
        }

        // PUT api/[controller]/{id}
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Companies user)
        {
            await _service.UpdateAsync(id, user);
        }

        // DELETE api/[controller]/{id}
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute]int id)
        {
            await _service.DeleteAsync(id);
        }
    }
}