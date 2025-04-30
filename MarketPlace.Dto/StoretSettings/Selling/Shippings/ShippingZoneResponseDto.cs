using MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;

namespace MarketPlace.Dto.StoretSettings.Shippings
{
    public class ShippingZoneResponseDto
    {
        public Guid Id { get; set; }
        public Guid ZoneRegionId { get; set; }
        public ZoneRegion ZoneRegion { get; set; }
        public List<ShippingZoneLocalizationDto>? Localizations { get; set; } = new();
    }
}
