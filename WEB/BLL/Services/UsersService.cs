using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Models;

namespace BLL.Services
{
    public class UsersService : AppService, IUsersService
    {
        public UsersService() : base()
        {
            
        }
        
        public async Task<List<Users>> GetAsync()
        {
            return (await Repo.UsersRepository.GetFromCache()).ToList();
        }

        public async Task<Users> GetByIdAsync(int id)
        {
            return (await Repo.UsersRepository.GetFromCache()).FirstOrDefault(i => i.Id == id);
        }

        public async Task UpdateAsync(int id, Users entity)
        {
            await Repo.UsersRepository.UpdateAsync(id, entity);
        }

        public async Task InsertAsync(Users entity)
        {
            await Repo.UsersRepository.InsertAsync(entity);
            await Repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await Repo.UsersRepository.DeleteAsync(id);
        }
    }
}
