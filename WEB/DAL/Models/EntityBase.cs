namespace DAL.Models
{
    public abstract class EntityBase<TId> : IEntityBase
    {
        public TId Id { get; protected set; } 
    }

    public interface IEntityBase
    { 
       
    }
}