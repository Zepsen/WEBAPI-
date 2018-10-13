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
        IWritableRepository<User, int>, 
        ICachedRepository<User>
    {
        private readonly ApplicationContext _db;
        
        public UsersRepository(ApplicationContext dbContext)
        {
            _db = dbContext;
        }
        
        #region ICachedRepository

        public async Task<IEnumerable<User>> GetFromCache()
        {
            return await _db.Users.FromCacheAsync(nameof(User));
        }
        

        public async Task<int> GetDeferredCountAsync()
        {
            return await _db.Users.DeferredCount().FromCacheAsync(nameof(User));
        }


        #endregion ICachedRepository

        #region IRepository

        public async Task InsertAsync(User entityToInsert)
        {
            await _db.Users.AddAsync(entityToInsert);
                

            Log.Information("Inserted");
            QueryCacheManager.ExpireTag(nameof(User));
            Log.Information("Cache cleared");
        }

        public async Task UpdateAsync(int id, User entityToUpdate)
        {
            await _db.Users
               .Where(i => i.Id == id)
               .UpdateFromQueryAsync(_ => new User
                {
                    Name = entityToUpdate.Name
                });

            Log.Information("Updated");
            QueryCacheManager.ExpireTag(nameof(User));
            Log.Information("Cache cleared");
        }

        public async Task UpdateSpecificAsync(int id, Dictionary<string, object> dictionary)
        {
            await _db.Users
                .Where(i => i.Id == id)
                .UpdateFromQueryAsync(ReposHelper.UpdateSpecificFields<User>(dictionary));

            Log.Information("Updated");
            QueryCacheManager.ExpireTag(nameof(User));
            Log.Information("Cache cleared");
        }

        public async Task DeleteAsync(int id)
        {
            await _db.Users
                .Where(i => i.Id == id)
                .DeleteFromQueryAsync();

            Log.Information("Deleted");
            QueryCacheManager.ExpireTag(nameof(User));
            Log.Information("Cache cleared");
        }
        

        #endregion IRepository

        
    }
}
