﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Infrastructure;
using BLL.Infrastructure.Filters;
using BLL.Interfaces;
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
        public async Task<Result<CompaniesDto>> Get(FilterBase filterBase)
        {
            return await _service.GetAsync(filterBase);
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