using MarketPlace.Domain.Entities.Common;

namespace MarketPlace.Domain.Entities.Products;

public class ProductSpecialOffer : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public decimal OfferPrice { get; set; }
    public DateTimeOffset Expiration { get; set; }
}
