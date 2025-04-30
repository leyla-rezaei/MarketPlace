namespace MarketPlace.Dto.Products
{
    public class ProductSpecialOfferRequestDto
    {
        public Guid ProductId { get; set; }
        public decimal OfferPrice { get; set; }
        public DateTimeOffset Expiration { get; set; }
    }

}