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
    public class CompaniesesService : AppService, ICompaniesService
    {
        private readonly IMapper _mapper;
        public CompaniesesService(ApplicationContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        

        public async Task<Result<CompanyDto>> GetAsync(FilterBase filter)
        {
            return await Repo.CompaniesRepository.GetQueryable()
                .MaybeWhere(filter.Where)
                .Searching(filter.Search) //mb delete, using dynamic linq where logic
                .MaybeOrderBy(filter.OrderBy)
                .SkipAndTake(filter)
                .MaybeSelect(filter.Select)
                .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
                .ToResultAsync(filter);
        }

        public async Task<CompanyDto> GetByIdAsync(int id)
        {
            return _mapper.Map<CompanyDto>(await Repo.CompaniesRepository.FindAsync(id));
        }

        public async Task UpdateAsync(int id, CompanyDto dto)
        {
            var entity = _mapper.Map<Company>(dto);
            await Repo.CompaniesRepository.UpdateAsync(id, entity);
        }

        public async Task UpdateSpecificAsync(int id, Dictionary<string, object> data)
        {
            await Repo.CompaniesRepository.UpdateSpecificAsync(id, data);
        }

        public async Task InsertAsync(CompanyDto dto)
        {
            var entity = _mapper.Map<Company>(dto);
            await Repo.CompaniesRepository.InsertAsync(entity);
            await Repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await Repo.CompaniesRepository.DeleteAsync(id);
        }

       
    }

    
}
