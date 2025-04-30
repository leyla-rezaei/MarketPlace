using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Enums.Selling;

namespace MarketPlace.Dto.StoretSettings.Selling.Promotions
{
    public class CouponResponseDto
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public string Code { get; set; }
        public DiscountType DiscountType { get; set; }
        public decimal? Percent { get; set; }
        public DateTimeOffset ValidFrom { get; set; }
        public DateTimeOffset ValidTo { get; set; }
        public int UsableCount { get; set; }
        public int Usage { get; set; }
        public decimal MinInvoiceLimit { get; set; }
        public decimal MaxInvoiceLimit { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public List<CouponLocalizationDto>? Localizations { get; set; } = new();
    }
}