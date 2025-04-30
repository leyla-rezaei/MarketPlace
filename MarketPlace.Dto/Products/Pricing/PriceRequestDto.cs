namespace MarketPlace.Dto.Products.Pricing
{
    public class PriceRequestDto
    {
        public Guid ProductId { get; set; }
        public Guid VariableProductId { get; set; }
        public decimal SalePrice { get; set; }
    }
}