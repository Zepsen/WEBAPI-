using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Interfaces
{
    public interface ICrudService<T> 
        where T : class
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(int id);

        Task UpdateAsync(int id, T entity);
        Task InsertAsync(T entity);
        Task DeleteAsync(int id);
    }
}