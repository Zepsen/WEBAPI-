using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class EditRoleModel
    {
        [Required]
        public string OldRole { get; set; }
        [Required]
        public string NewRole { get; set; }

    }
}