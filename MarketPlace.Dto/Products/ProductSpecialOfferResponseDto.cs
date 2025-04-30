using MarketPlace.Domain.Entities.Products;

namespace MarketPlace.Dto.Products
{
    public class ProductSpecialOfferResponseDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public decimal OfferPrice { get; set; }
        public DateTimeOffset Expiration { get; set; }
    }
}
