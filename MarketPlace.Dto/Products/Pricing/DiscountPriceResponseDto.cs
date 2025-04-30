using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Entities.Products.ProductTypes;

namespace MarketPlace.Dto.Products.Pricing
{
    public class DiscountPriceResponseDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid VariableProductId { get; set; }
        public VariableProduct VariableProduct { get; set; }
        public decimal SalePrice { get; set; }
        public DateTimeOffset SalePriceFrom { get; set; }
        public DateTimeOffset SalePriceTo { get; set; }
    }
}