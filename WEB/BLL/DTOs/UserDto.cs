using BLL.Interfaces;
using DAL.Models;

namespace BLL.DTOs
{
    /// <summary>
    /// <see cref="User"/>
    /// </summary>
    public class UserDto : IDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserIdentityId { get; set; }


        public static UserDto Default(string id, string name)
        {
            return new UserDto()
            {
                UserIdentityId = id,
                Name = name,
            };
        }
    }
}