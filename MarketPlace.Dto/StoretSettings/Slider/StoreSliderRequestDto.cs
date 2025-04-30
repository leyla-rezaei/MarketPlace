namespace MarketPlace.Dto.StoretSettings.Slider
{
    public class StoreSliderRequestDto
    {
      public List<StoreSliderLocalizationDto>? Localizations { get; set; }
    }
    public class StoreSliderLocalizationDto
    {
        public string Key { get; set; }
        public string? SliderName { get; set; }
    }
}
