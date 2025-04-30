namespace MarketPlace.Dto.Products.Pricing
{
    public class DiscountPriceRequestDto
    {
        public Guid ProductId { get; set; }
        public Guid VariableProductId { get; set; }
        public decimal SalePrice { get; set; }
        public DateTimeOffset SalePriceFrom { get; set; }
        public DateTimeOffset SalePriceTo { get; set; }
    }
}
