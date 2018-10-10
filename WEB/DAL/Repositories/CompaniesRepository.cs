using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Infrastructure.Helpers;
using DAL.Interfaces;
using DAL.Models;
using Serilog;

namespace DAL.Repositories
{
    public class CompaniesRepository :
        IWritableRepository<Company, int>,
        IQueryableRepository<Company, int>
    {
        private readonly ApplicationContext _db;

        public CompaniesRepository(ApplicationContext dbContext)
        {
            _db = dbContext;
        }

        #region IQueryableRepository

        public IQueryable<Company> GetQueryable()
        {
            return _db.Companies.AsQueryable();
        }

        public async Task<Company> FindAsync(int id)
        {
            return await _db.Companies.FindAsync(id);
        }


        #endregion IQueryableRepository

        #region IRepository

        public async Task InsertAsync(Company entityToInsert)
        {
            await _db.Companies.AddAsync(entityToInsert);
            Log.Information("Inserted");
        }

        public async Task UpdateAsync(int id, Company entityToUpdate)
        {

            await _db.Companies
                .Where(i => i.Id == id)
                .UpdateFromQueryAsync(_ => new Company
                {
                    Name = entityToUpdate.Name
                });

            Log.Information("Updated");
        }

        public async Task UpdateSpecificAsync(int id, Dictionary<string, object> dictionary)
        {
            await _db.Companies
                .Where(i => i.Id == id)
                .UpdateFromQueryAsync(ReposHelper.UpdateSpecificFields<Company>(dictionary));

            Log.Information("Updated");
        }

        

        public async Task DeleteAsync(int id)
        {
            await _db.Companies
                .Where(i => i.Id == id)
                .DeleteFromQueryAsync();

            Log.Information("Deleted");
        }


        #endregion IRepository


    }
}
