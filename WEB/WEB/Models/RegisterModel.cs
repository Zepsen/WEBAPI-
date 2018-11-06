using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class RegisterModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Confirm password invalid")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}