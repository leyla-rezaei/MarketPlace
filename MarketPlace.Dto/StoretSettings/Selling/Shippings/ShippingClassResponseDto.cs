using MarketPlace.Domain.Entities.StoretSettings;

namespace MarketPlace.Dto.StoretSettings.Shippings
{
    public class ShippingClassResponseDto
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public int ProductCount { get; set; }
        public List<ShippingClassLocalizationDto>? Localizations { get; set; } = new();
    }
}
