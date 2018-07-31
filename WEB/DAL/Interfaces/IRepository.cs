using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IWritableRepository<T> 
        where T : class
    {
        Task InsertAsync(T entityToInsert);
        Task UpdateAsync(int id, T entityToUpdate);
        Task DeleteAsync(int id);
    }

    public interface IQueryableRepository<T>
        where T : class
    {
        IQueryable<T> GetQueryable();
        
        Task<T> FindAsync(int id);
    }

    public interface ICachedRepository<T>
        where T : class
    {
        Task<IEnumerable<T>> GetFromCache();
        Task<int> GetDeferredCountAsync();
    }
}