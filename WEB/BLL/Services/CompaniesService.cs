using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using BLL.Infrastructure;
using BLL.Infrastructure.Extensions;
using BLL.Infrastructure.Extensions.EntitiesExts;
using BLL.Infrastructure.Filters;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class CompaniesService : AppService, ICompaniesService
    {
        private readonly IMapper _mapper;
        public CompaniesService(IMapper mapper) : base()
        {
            _mapper = mapper;
        }
        

        public async Task<Result<CompaniesDto>> GetAsync(FilterBase filter)
        {
            return await Repo.CompaniesRepository.GetQueryable()
                .Searching(filter.Query)
                .SkipAndTake(filter)
                .MapTo<Companies, CompaniesDto>(filter.Fields, _mapper.ConfigurationProvider)
                .ToResultAsync();
        }

        public async Task<CompaniesDto> GetByIdAsync(int id)
        {
            return _mapper.Map<CompaniesDto>(await Repo.CompaniesRepository.FindAsync(id));
        }

        public async Task UpdateAsync(int id, CompaniesDto dto)
        {
            var entity = _mapper.Map<Companies>(dto);
            await Repo.CompaniesRepository.UpdateAsync(id, entity);
        }

        public async Task InsertAsync(CompaniesDto dto)
        {
            var entity = _mapper.Map<Companies>(dto);
            await Repo.CompaniesRepository.InsertAsync(entity);
            await Repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await Repo.CompaniesRepository.DeleteAsync(id);
        }
    }

    
}
