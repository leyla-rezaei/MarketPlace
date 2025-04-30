using MarketPlace.Domain.Enums;

namespace MarketPlace.Dto.Categories
{
    public class CategoryRequestDto
    {
        public CategoryType CategoryType { get; set; }
        public List<CategoryLocalizationDto>? Localizations { get; set; }
    }

    public class CategoryLocalizationDto
    {
        public string Key { get; set; }
        public Guid ParentCategoryId { get; set; } = Guid.Empty;
        public string? Title { get; set; }
        public string? Slug { get; set; }
        public string? Description { get; set; }
    }
}