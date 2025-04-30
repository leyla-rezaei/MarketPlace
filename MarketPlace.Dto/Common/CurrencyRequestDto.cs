namespace MarketPlace.Dto.Common
{
    public class CurrencyRequestDto
    {
        public Guid Id { get; set; }
        public List<CurrencyLocalizationDto>? Localizations { get; set; }
    }

    public class CurrencyLocalizationDto
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string Symbole { get; set; }
    }
}
