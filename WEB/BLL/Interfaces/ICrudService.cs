using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Infrastructure;
using BLL.Infrastructure.Filters;

namespace BLL.Interfaces
{
    public interface ICrudService<T, TId> 
        where T : class
    {
        Task<Result<T>> GetAsync(FilterBase filterBase);
        Task<T> GetByIdAsync(TId id);

        Task UpdateAsync(TId id, T entity);
        Task UpdateSpecificAsync(TId id, Dictionary<string, object> dictionary);

        Task InsertAsync(T entity);
        Task DeleteAsync(TId id);
    }
}