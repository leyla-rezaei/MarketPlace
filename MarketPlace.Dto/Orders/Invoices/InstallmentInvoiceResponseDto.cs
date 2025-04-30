using MarketPlace.Domain.Entities.Orders.ShoppingCards;
using MarketPlace.Domain.Entities.Products.Pricing;

namespace MarketPlace.Dto.Orders.Invoices
{
    public class InstallmentInvoiceResponseDto
    {
        public Guid Id { get; set; }
        public Guid ShoppingCardDetailId { get; set; }
        public ShoppingCardDetail ShoppingCardDetail { get; set; }

        public uint InstallmentNumber { get; set; }

        public Guid PriceId { get; set; }
        public Price Price { get; set; }

        public decimal Payable { get; set; }

        public bool IsPayed { get; set; }
        public DateTimeOffset PaidOn { get; set; }
    }
}
