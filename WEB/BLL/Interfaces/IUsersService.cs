using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IUsersService : ICrudService<UserDto, int>
    {
        Task<UserDto> GetByEmailAsync(string email);
    }
}