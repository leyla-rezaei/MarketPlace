namespace MarketPlace.Dto.StoretSettings.Selling.PayGateSetting
{
    public class PayPalSettingRequestDto
    {
        public Guid StoreId { get; set; }
        public bool IsEanbled { get; set; }
        public int RequestRetries { get; set; }
        public int ConnectionTimeout { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public List<PayPalSettingLocalizationDto>? Localizations { get; set; }
    }

    public class PayPalSettingLocalizationDto
    {
        public string Key { get; set; }
        public string Mode { get; set; }

    }
}
