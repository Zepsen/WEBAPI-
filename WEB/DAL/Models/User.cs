using DAL.Interfaces;

namespace DAL.Models
{
    public class User : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UserIdentity UserIdentity { get; set; }
        public string UserIdentityId { get; set; }
    }
}
