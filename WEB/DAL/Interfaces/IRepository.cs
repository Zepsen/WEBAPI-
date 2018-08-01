using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IWritableRepository<in T> 
        where T : IEntityBase
    {
        Task InsertAsync(T entityToInsert);
        Task UpdateAsync(int id, T entityToUpdate);
        Task DeleteAsync(int id);
    }

    public interface IQueryableRepository<T>
        where T : IEntityBase
    {
        IQueryable<T> GetQueryable();
        
        Task<T> FindAsync(int id);
    }

    public interface ICachedRepository<T>
        where T : IEntityBase
    {
        Task<IEnumerable<T>> GetFromCache();
        Task<int> GetDeferredCountAsync();
    }
}