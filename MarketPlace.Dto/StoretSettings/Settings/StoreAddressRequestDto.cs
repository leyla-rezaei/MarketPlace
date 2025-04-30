namespace MarketPlace.StoretSettings.Settings
{
    public class StoreAddressRequestDto
    {
        public Guid StoreId { get; set; }
        public Guid CityId { get; set; }
        public List<StoreAddressLocalizationDto>? Localizations { get; set; }
    }

    public class StoreAddressLocalizationDto
    {
        public string Key { get; set; }
        public string? Address { get; set; }
        public string? ZipCode { get; set; }
        public string? PostalCode { get; set; }
    }
}
