namespace MarketPlace.Dto.StoretSettings.Shippings
{
    public class ShippingClassRequestDto
    {
        public int ProductCount { get; set; }
        public Guid StoreId { get; set; }
        public List<ShippingClassLocalizationDto>? Localizations { get; set; }

    }
    public class ShippingClassLocalizationDto
    {
        public string Key { get; set; }
        public string ClassName { get; set; }
        public string Slug { get; set; }
        public string? Description { get; set; }
    }
}