using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersService _service;
        
        public UsersController(
            IUsersService service)
        {
            _service = service;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Users>> Get()
        {
            return await _service.GetUsersAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Users> Get([FromRoute]int id)
        {
            return await _service.GetUserAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]Users user)
        {
            await _service.InsertUserAsync(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Users user)
        {
            await _service.UpdateUserAsync(id, user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.DeleteUserAsync(id);
        }
    }
}
