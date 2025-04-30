namespace MarketPlace.Domain.Entities.Common
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset? ModificationDate { get; set; }
        public bool IsArchived { get; set; }

        public Guid? CreatedById { get; set; }

        public Guid? LastModificationById { get; set; }
    }
}
