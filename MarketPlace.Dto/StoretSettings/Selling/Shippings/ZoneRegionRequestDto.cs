namespace MarketPlace.Dto.StoretSettings.Shippings
{
    public class ZoneRegionRequestDto
    {
        public List<ZoneRegionLocalizationDto>? Localizations { get; set; }
    }

    public class ZoneRegionLocalizationDto
    {
        public string Key { get; set; }
        public string? Region1 { get; set; }
        public string? Region2 { get; set; }
        public string? Region3 { get; set; }
    }
}
