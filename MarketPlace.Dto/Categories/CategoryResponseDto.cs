using MarketPlace.Domain.Entities.Categories;
using MarketPlace.Domain.Enums;

namespace MarketPlace.Dto.Categories
{
    public class CategoryResponseDto
    {
        public Guid Id { get; set; }
        public Guid ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public CategoryType CategoryType { get; set; }
        public List<CategoryLocalizationDto>? Localizations { get; set; } = new();
    }
}
