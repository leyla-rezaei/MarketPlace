using MarketPlace.Domain.Entities.Products;

namespace MarketPlace.Dto.Products.Installment
{
    public class ProductInstallmentResponseDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public uint NumberOfInstallment { get; set; }
        public decimal BenefitPercent { get; set; }
    }
}
