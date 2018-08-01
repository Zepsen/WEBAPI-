using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using BLL.Infrastructure;
using BLL.Infrastructure.Filters;
using BLL.Interfaces;
using DAL.Models;

namespace BLL.Services
{
    public class UsersService : AppService, IUsersService
    {
        private readonly IMapper _mapper;
        public UsersService(IMapper mapper) : base()
        {
            _mapper = mapper;
        }
        
        public async Task<Result<UsersDto>> GetAsync(FilterBase filter)
        {
            var entity = (await Repo.UsersRepository.GetFromCache()).ToList();
            return new Result<UsersDto>()
            {
                Data = _mapper.Map<List<UsersDto>>(entity)
            };
        }

        public async Task<UsersDto> GetByIdAsync(int id)
        {
            var entity = (await Repo.UsersRepository.GetFromCache()).FirstOrDefault(i => i.Id == id);
            return _mapper.Map<UsersDto>(entity);
        }

        public async Task UpdateAsync(int id, UsersDto dto)
        {
            var entity = _mapper.Map<Users>(dto);
            await Repo.UsersRepository.UpdateAsync(id, entity);
        }

        public async Task InsertAsync(UsersDto dto)
        {
            var entity = _mapper.Map<Users>(dto);
            await Repo.UsersRepository.InsertAsync(entity);
            await Repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await Repo.UsersRepository.DeleteAsync(id);
        }
    }
}
