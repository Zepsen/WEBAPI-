using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Services;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BLL
{
    public class CompaniesService : AppService, ICompaniesService
    {        
        
        public CompaniesService() : base()
        {
            
        }
        
        public async Task<List<Companies>> GetAsync()
        {
            return await Repo.CompaniesRepository.GetQueryable().ToListAsync();
        }

        public async Task<Companies> GetByIdAsync(int id)
        {
            return (await Repo.CompaniesRepository.FindAsync(id));
        }

        public async Task UpdateAsync(int id, Companies user)
        {
            Log.Information("Params {@user}", user);
            await Repo.CompaniesRepository.UpdateAsync(id, user);
        }

        public async Task InsertAsync(Companies user)
        {
            await Repo.CompaniesRepository.InsertAsync(user);
            await Repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await Repo.CompaniesRepository.DeleteAsync(id);
        }
    }
}
