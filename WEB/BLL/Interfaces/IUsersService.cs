using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Interfaces
{
    public interface IUsersService
    {
        Task<List<Users>> GetUsersAsync();
        Task<Users> GetUserAsync(int id);

        Task DeleteUserAsync(int id);
        Task InsertUserAsync(Users user);
        Task UpdateUserAsync(int id, Users user);

    }
}