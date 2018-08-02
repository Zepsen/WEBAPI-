using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Infrastructure.Helpers;
using DAL.Interfaces;
using DAL.Models;
using Serilog;
using Z.EntityFramework.Plus;

namespace DAL.Repositories
{
    public class UsersRepository : 
        IWritableRepository<Users>, 
        ICachedRepository<Users>
    {
        private readonly ApplicationContext _db;
        
        public UsersRepository(ApplicationContext dbContext)
        {
            _db = dbContext;
        }
        
        #region ICachedRepository

        public async Task<IEnumerable<Users>> GetFromCache()
        {
            return await _db.Users.FromCacheAsync(nameof(Users));
        }
        

        public async Task<int> GetDeferredCountAsync()
        {
            return await _db.Users.DeferredCount().FromCacheAsync(nameof(Users));
        }


        #endregion ICachedRepository

        #region IRepository

        public async Task InsertAsync(Users entityToInsert)
        {
            await _db.Users.AddAsync(entityToInsert);
                

            Log.Information("Inserted");
            QueryCacheManager.ExpireTag(nameof(Users));
            Log.Information("Cache cleared");
        }

        public async Task UpdateAsync(int id, Users entityToUpdate)
        {
            await _db.Users
               .Where(i => i.Id == id)
               .UpdateFromQueryAsync(_ => new Users
                {
                    Name = entityToUpdate.Name
                });

            Log.Information("Updated");
            QueryCacheManager.ExpireTag(nameof(Users));
            Log.Information("Cache cleared");
        }

        public async Task UpdateSpecificAsync(int id, Dictionary<string, object> dictionary)
        {
            await _db.Users
                .Where(i => i.Id == id)
                .UpdateFromQueryAsync(ReposHelper.UpdateSpecificFields<Users>(dictionary));

            Log.Information("Updated");
            QueryCacheManager.ExpireTag(nameof(Users));
            Log.Information("Cache cleared");
        }

        public async Task DeleteAsync(int id)
        {
            await _db.Users
                .Where(i => i.Id == id)
                .DeleteFromQueryAsync();

            Log.Information("Deleted");
            QueryCacheManager.ExpireTag(nameof(Users));
            Log.Information("Cache cleared");
        }
        

        #endregion IRepository

        
    }
}
