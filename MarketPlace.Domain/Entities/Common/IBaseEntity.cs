namespace MarketPlace.Domain.Entities.Common;

public interface IBaseEntity : IMarketPlaceEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset CreationDate { get; set; }
    public DateTimeOffset? ModificationDate { get; set; }
    public bool IsArchived { get; set; }
}
public interface IMarketPlaceEntity { }
