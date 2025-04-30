namespace MarketPlace.Dto.StoretSettings.Slider
{
    public class StoreSliderResponseDto
    {
        public Guid Id { get; set; }
        public List<StoreSliderLocalizationDto>? Localizations { get; set; } = new();
    }
}
