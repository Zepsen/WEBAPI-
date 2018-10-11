using DAL.Interfaces;

namespace DAL.Models
{
    public class User : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Email { get; set; }
        public string Role { get; set; }
        
    }
}
