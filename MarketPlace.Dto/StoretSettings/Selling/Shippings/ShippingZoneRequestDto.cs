namespace MarketPlace.Dto.StoretSettings.Shippings
{
    public class ShippingZoneRequestDto
    {
        public Guid ZoneRegionId { get; set; }
        public List<ShippingZoneLocalizationDto>? Localizations { get; set; }
    }

    public class ShippingZoneLocalizationDto
    {
        public string Key { get; set; }
        public string? ZoneName { get; set; }
    }
}
