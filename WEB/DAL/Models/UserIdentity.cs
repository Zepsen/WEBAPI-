using Microsoft.AspNetCore.Identity;

namespace DAL.Models
{
    public class UserIdentity : IdentityUser
    {
        public User User { get; set; }
    }
}