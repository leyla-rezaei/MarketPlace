namespace MarketPlace.Domain.Entities.Common;

public abstract class BaseLocalization : BaseEntity
{
    public string Key { get; set; } = string.Empty;
}
