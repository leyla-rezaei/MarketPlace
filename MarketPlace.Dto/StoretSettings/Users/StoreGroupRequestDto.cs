namespace MarketPlace.Dto.StoretSettings.Users
{
    public class StoreGroupRequestDto
    {
        public Guid StoreId { get; set; }
        public List<StoreGroupLocalizationDto>? Localizations { get; set; }
    }
    public class StoreGroupLocalizationDto
    {
        public string Key { get; set; }
        public string? Title { get; set; }
    }
}