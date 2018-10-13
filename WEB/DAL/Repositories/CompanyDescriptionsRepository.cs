using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Infrastructure.Helpers;
using DAL.Interfaces;
using DAL.Models;
using Serilog;

namespace DAL.Repositories
{
    public class CompanyDescriptionsRepository :
        IWritableRepository<CompanyDescriptions>,
        IQueryableRepository<CompanyDescriptions>
    {
        private readonly ApplicationContext _db;

        public CompanyDescriptionsRepository(ApplicationContext dbContext)
        {
            _db = dbContext;
        }

        #region IQueryableRepository

        public IQueryable<CompanyDescriptions> GetQueryable()
        {
            return _db.CompanyDescriptions.AsQueryable();
        }

        public async Task<CompanyDescriptions> FindAsync(int id)
        {
            return await _db.CompanyDescriptions.FindAsync(id);
        }


        #endregion IQueryableRepository

        #region IRepository

        public async Task InsertAsync(CompanyDescriptions entityToInsert)
        {
            await _db.CompanyDescriptions.AddAsync(entityToInsert);
            Log.Information("Inserted");
        }

        public async Task UpdateAsync(int id, CompanyDescriptions entityToUpdate)
        {

            await _db.CompanyDescriptions
                .Where(i => i.Id == id)
                .UpdateFromQueryAsync(_ => new CompanyDescriptions
                {
                    Description = entityToUpdate.Description,
                });

            Log.Information("Updated");
        }

        public async Task UpdateSpecificAsync(int id, Dictionary<string, object> dictionary)
        {
            await _db.CompanyDescriptions
                .Where(i => i.Id == id)
                .UpdateFromQueryAsync(ReposHelper.UpdateSpecificFields<CompanyDescriptions>(dictionary));

            Log.Information("Updated");
        }

        

        public async Task DeleteAsync(int id)
        {
            await _db.CompanyDescriptions
                .Where(i => i.Id == id)
                .DeleteFromQueryAsync();

            Log.Information("Deleted");
        }


        #endregion IRepository


    }
}
