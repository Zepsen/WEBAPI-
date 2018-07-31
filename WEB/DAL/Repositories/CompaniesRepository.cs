using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using Serilog;

namespace DAL.Repositories
{
    public class CompaniesRepository : 
        IWritableRepository<Companies>, 
        IQueryableRepository<Companies>
    {
        private readonly ApplicationContext _db;
        
        public CompaniesRepository(ApplicationContext dbContext)
        {
            _db = dbContext;
        }

        #region IQueryableRepository

        public IQueryable<Companies> GetQueryable()
        {
            return _db.Companies.AsQueryable();
        }

        public async Task<Companies> FindAsync(int id)
        {
            return await _db.Companies.FindAsync(id);
        }


        #endregion IQueryableRepository

        #region IRepository

        public async Task InsertAsync(Companies entityToInsert)
        {
            await _db.Companies.AddAsync(entityToInsert);
            Log.Information("Inserted");
        }

        public async Task UpdateAsync(int id, Companies entityToUpdate)
        {
            await _db.Companies
               .Where(i => i.Id == id)
               .UpdateFromQueryAsync(_ => new Companies
                {
                    Name = entityToUpdate.Name
                });

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
