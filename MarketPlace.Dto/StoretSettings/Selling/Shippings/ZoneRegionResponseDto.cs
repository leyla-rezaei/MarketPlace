namespace MarketPlace.Dto.StoretSettings.Shippings
{
    public class ZoneRegionResponseDto
    {
        public Guid Id { get; set; }
        public List<ZoneRegionLocalizationDto>? Localizations { get; set; } = new();
    }
}
