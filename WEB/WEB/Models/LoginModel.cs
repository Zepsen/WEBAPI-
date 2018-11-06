using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class LoginModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; } = false;

        public string ReturnUrl { get; set; }

    }
}