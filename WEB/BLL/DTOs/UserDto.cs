using BLL.Interfaces;
using DAL.Models;

namespace BLL.DTOs
{
    public class UserDto : IDto
    {
        public string Id { get; set; }
        public string Name { get; set; }


        public UserDto(string name)
        {
            Name = name;
        }
    }
}