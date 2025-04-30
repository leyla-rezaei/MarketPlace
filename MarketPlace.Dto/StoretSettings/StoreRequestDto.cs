namespace MarketPlace.Dto.StoretSettings
{
    public class StoreRequestDto
    {
        public Guid OwnerId { get; set; }
        public Guid? StoreIconId { get; set; }
        public string? Domain { get; set; }
        public Guid StoreTypeId { get; set; }
        public List<StoreLocalizationDto>? Localizations { get; set; }  
    }

    public class StoreLocalizationDto
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
