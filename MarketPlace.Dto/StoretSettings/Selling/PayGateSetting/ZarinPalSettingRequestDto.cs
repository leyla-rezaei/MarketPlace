namespace MarketPlace.Dto.StoretSettings.Selling.PayGateSetting
{
    public class ZarinPalSettingRequestDto
    {
        public Guid StoreId { get; set; }
        public bool IsEanbled { get; set; }
        public List<ZarinPalSettingLocalizationDto>? Localizations { get; set; }
    }
    public class ZarinPalSettingLocalizationDto
    {
        public string Key { get; set; }
        public string MerchentCode { get; set; }
    }
}
