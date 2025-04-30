namespace MarketPlace.Dto.StoretSettings
{
    public class FAQRequestDto
    {
        public Guid StoreId { get; set; }
        public int Order { get; set; }

        public List<FAQLocalizationDto>? Localizations { get; set; }
    }
    public class FAQLocalizationDto
    {
        public string Key { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
    }
}
