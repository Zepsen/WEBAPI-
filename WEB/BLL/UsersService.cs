using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BLL
{
    public class UsersService : IUsersService
    {
        private readonly RepoWorker _repo;
        
        public UsersService()
        {
            _repo = new RepoWorker();
        }
        

        public async Task<List<Users>> GetUsersAsync()
        {
            return (await _repo.UsersRepository.GetFromCache()).ToList();
        }

        public async Task<Users> GetUserAsync(int id)
        {
            return (await _repo.UsersRepository.GetFromCache()).FirstOrDefault(i => i.Id == id);
        }

        public async Task UpdateUserAsync(int id, Users user)
        {
            Log.Information("Params {@user}", user);
            await _repo.UsersRepository.UpdateAsync(id, user);
        }

        public async Task InsertUserAsync(Users user)
        {
            await _repo.UsersRepository.InsertAsync(user);
            await _repo.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            await _repo.UsersRepository.DeleteAsync(id);
        }
    }
}
