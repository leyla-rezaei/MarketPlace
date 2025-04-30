namespace MarketPlace.Dto.StoretSettings.Settings
{
    public class StoreTypeRequestDto
    {
        public List<StoreTypeLocalizationDto>? Localizations { get; set; }
    }
    public class StoreTypeLocalizationDto
    {
        public string Key { get; set; }
        public string? Type { get; set; }
    }
}