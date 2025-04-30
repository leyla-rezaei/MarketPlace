using MarketPlace.Domain.Enums.Selling;

namespace MarketPlace.Dto.StoretSettings.Selling.Promotions
{
    public class CouponRequestDto
    {
        public Guid StoreId { get; set; }
        public string Code { get; set; }
        public DiscountType DiscountType { get; set; }
        public decimal Percent { get; set; }
        public DateTimeOffset ValidFrom { get; set; }
        public DateTimeOffset ValidTo { get; set; }
        public int UsableCount { get; set; }
        public int Usage { get; set; }
        public decimal MinInvoiceLimit { get; set; }
        public decimal MaxInvoiceLimit { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public List<CouponLocalizationDto>? Localizations { get; set; }
    }

    public class CouponLocalizationDto
    {
        public string Key { get; set; }
        public string? Description { get; set; }
    }
}
