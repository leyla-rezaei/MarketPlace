namespace MarketPlace.Dto.Products.Installment
{
    public class ProductInstallmentRequestDto
    {
        public Guid ProductId { get; set; }
        public uint NumberOfInstallment { get; set; }
        public decimal BenefitPercent { get; set; }
    }
}