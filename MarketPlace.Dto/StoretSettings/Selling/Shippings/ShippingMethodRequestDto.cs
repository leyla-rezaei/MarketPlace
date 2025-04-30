namespace MarketPlace.Dto.StoretSettings.Shippings
{
    public class ShippingMethodRequestDto
    {
        public Guid StoreId { get; set; }
        public bool IsEnabled { get; set; }
        public List<ShippingMethodLocalizationDto>? Localizations { get; set; }
    }

    public class ShippingMethodLocalizationDto
    {
        public string Key { get; set; }
        public string MethodTitle { get; set; }
        public string? Description { get; set; }
    }
}
