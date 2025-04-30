using MarketPlace.Domain.Entities.StoretSettings;

namespace MarketPlace.Dto.StoretSettings.Selling.PayGateSetting
{
    public class PayPalSettingResponseDto
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public int RequestRetries { get; set; }
        public int ConnectionTimeout { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public List<PayPalSettingLocalizationDto>? Localizations { get; set; } = new();
    }
}
