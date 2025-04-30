using MarketPlace.Domain.Enums;
namespace MarketPlace.Dto.Tags
{
    public class TagRequestDto
    {
        public bool IsApproved { get; set; }
        public TagType? TagType { get; set; }
        public List<TagLocalizationDto>? Localizations { get; set; }
    }
    public class TagLocalizationDto
    {
        public string Key { get; set; }
        public string? TagName { get; set; }
    }
}
