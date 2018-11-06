using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.DTOs;
using BLL.Infrastructure;
using BLL.Infrastructure.Extensions;
using BLL.Infrastructure.Extensions.EntitiesExts;
using BLL.Infrastructure.Filters;
using BLL.Interfaces;
using DAL;
using DAL.Models;

namespace BLL.Services
{
    public class CompanyDescriptionsService : AppService, ICompanyDescriptionsService
    {
        private readonly IMapper _mapper;
        public CompanyDescriptionsService(ApplicationContext context,  IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        

        public async Task<Result<CompanyDescriptionsDto>> GetAsync(FilterBase filter)
        {
            return await Repo.CompanyDescriptionsRepository.GetQueryable()
                .MaybeWhere(filter.Where)
                .Searching(filter.Search) //mb delete, using dynamic linq where logic
                .MaybeOrderBy(filter.OrderBy)
                .SkipAndTake(filter)
                .MaybeSelect(filter.Select)
                .ProjectTo<CompanyDescriptionsDto>(_mapper.ConfigurationProvider)
                .ToResultAsync(filter);
        }

        public async Task<CompanyDescriptionsDto> GetByIdAsync(int id)
        {
            return _mapper.Map<CompanyDescriptionsDto>(await Repo.CompanyDescriptionsRepository.FindAsync(id));
        }

        public async Task UpdateAsync(int id, CompanyDescriptionsDto dto)
        {
            var entity = _mapper.Map<CompanyDescriptions>(dto);
            await Repo.CompanyDescriptionsRepository.UpdateAsync(id, entity);
        }

        public async Task UpdateSpecificAsync(int id, Dictionary<string, object> data)
        {
            await Repo.CompanyDescriptionsRepository.UpdateSpecificAsync(id, data);
        }

        public async Task InsertAsync(CompanyDescriptionsDto dto)
        {
            var entity = _mapper.Map<CompanyDescriptions>(dto);
            await Repo.CompanyDescriptionsRepository.InsertAsync(entity);
            await Repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await Repo.CompanyDescriptionsRepository.DeleteAsync(id);
        }

       
    }

    
}
