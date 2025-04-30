using MarketPlace.Domain.Enums.Selling;

namespace MarketPlace.Dto.Settings
{
    public class MarketSettingRequestDto
    {
        public PaymentType PrimaryPaymentType { get; set; }
        public PaymentType SecondaryPaymentType { get; set; }
        public List<MarketSettingLocalizationDto>? Localizations { get; set; }
    }

    public class MarketSettingLocalizationDto
    {
        public string Key { get; set; }
    }
}