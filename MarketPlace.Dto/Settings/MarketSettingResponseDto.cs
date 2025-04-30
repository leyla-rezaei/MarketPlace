using MarketPlace.Domain.Enums.Selling;

namespace MarketPlace.Dto.Settings
{
    public class MarketSettingResponseDto
    {
        public Guid Id { get; set; }
        //public string Language { get; set; }
        public PaymentType PrimaryPaymentType { get; set; }
        public PaymentType SecondaryPaymentType { get; set; }
        public List<MarketSettingLocalizationDto>? Localizations { get; set; } = new();
    }
}
