using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Infrastructure.Filters;

namespace BLL.Interfaces
{
    public interface ICrudService<T> 
        where T : class
    {
        Task<List<T>> GetAsync(FilterBase filterBase);
        Task<T> GetByIdAsync(int id);

        Task UpdateAsync(int id, T entity);
        Task InsertAsync(T entity);
        Task DeleteAsync(int id);
    }
}