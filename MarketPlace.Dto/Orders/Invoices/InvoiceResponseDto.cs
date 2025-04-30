using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Orders.ShoppingCards;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Promotions;
using MarketPlace.Domain.Enums.Order;

namespace MarketPlace.Dto.Orders.Invoices
{
    public class InvoiceResponseDto
    {
        public Guid Id { get; set; }
        public OrderAction OrderAction { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid ShoppingCardId { get; set; }
        public ShoppingCard ShoppingCard { get; set; }

        public string InvoiceNumber { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public decimal Discount { get; set; }

        public Guid CouponId { get; set; }
        public Coupon Coupon { get; set; }

        public decimal Amount { get; set; }
        public decimal Payable => Amount - Discount;
        public bool IsPaid { get; set; }
        public DateTimeOffset PaidOn { get; set; }

        public List<InvoiceLocalizationDto>? Localizations { get; set; } = new();
    }
}