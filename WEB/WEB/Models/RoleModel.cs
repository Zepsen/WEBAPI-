using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class RoleModel
    {
        [Required]
        public string Role { get; set; }
    }
}