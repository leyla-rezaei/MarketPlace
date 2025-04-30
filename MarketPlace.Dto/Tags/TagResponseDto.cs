using MarketPlace.Domain.Enums;

namespace MarketPlace.Dto.Tags
{
    public class TagResponseDto
    {
        public Guid Id { get; set; }
        public string TagName { get; set; }
        public bool IsApproved { get; set; }
        public TagType TagType { get; set; }
        public List<TagLocalizationDto>? Localizations { get; set; } = new ();
    }
}
