using DAL.Interfaces;

namespace DAL.Models
{
    public class User : IEntityBase
    {
        public new int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
