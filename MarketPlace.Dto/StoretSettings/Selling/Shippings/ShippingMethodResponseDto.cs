using MarketPlace.Domain.Entities.StoretSettings;

namespace MarketPlace.Dto.StoretSettings.Shippings
{
    public class ShippingMethodResponseDto
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public string MethodTitle { get; set; }
        public bool IsEnabled { get; set; }
        public List<ShippingMethodLocalizationDto>? Localizations { get; set; } = new();
    }
}
