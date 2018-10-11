using System.Collections.Generic;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BLL.DTOs
{
    /// <summary>
    /// <see cref="User"/>
    /// </summary>
    public class UserDto : IDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        
        public string Email { get; set; }
        public string Role { get; set; }
    }
}