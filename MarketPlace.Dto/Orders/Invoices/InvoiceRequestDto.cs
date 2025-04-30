using MarketPlace.Domain.Enums.Order;

namespace MarketPlace.Dto.Orders.Invoices
{
    public class InvoiceRequestDto
    {
        public OrderAction OrderAction { get; set; }
        public Guid UserId { get; set; }
        public Guid ShoppingCardId { get; set; }
        public string? InvoiceNumber { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal Discount { get; set; }
        public Guid? CouponId { get; set; }
        public decimal Amount { get; set; }
        public decimal Payable => Amount - Discount;
        public bool IsPaid { get; set; }
        public DateTimeOffset PaidOn { get; set; }
        public List<InvoiceLocalizationDto>? Localizations { get; set; }
    }

    public class InvoiceLocalizationDto
    {
        public string Key { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CustomerProvidedNote { get; set; }
    }
}

