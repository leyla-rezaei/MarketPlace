namespace MarketPlace.Dto.Common
{
    public class CurrencyResponseDto
    {
        public Guid Id { get; set; }
        public List<CurrencyLocalizationDto>? Localizations { get; set; } = new();
    }
}
