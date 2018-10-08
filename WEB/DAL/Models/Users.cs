namespace DAL.Models
{
    public class Users : EntityBase<int>
    {
        public new int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
