using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IWritableRepository<in T, in TId> 
        where T : IEntityBase
    {
        Task InsertAsync(T entityToInsert);
        Task UpdateAsync(TId id, T entityToUpdate);
        Task UpdateSpecificAsync(TId id, Dictionary<string, object> dictionary);
        Task DeleteAsync(TId id);
    }

    public interface IQueryableRepository<T, in TId>
        where T : IEntityBase
    {
        IQueryable<T> GetQueryable();
        
        Task<T> FindAsync(TId id);
    }

    public interface ICachedRepository<T>
        where T : IEntityBase
    {
        Task<IEnumerable<T>> GetFromCache();
        Task<int> GetDeferredCountAsync();
    }
}