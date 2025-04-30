using MarketPlace.Domain.Enums;

namespace MarketPlace.Dto.SiteSettings
{
    public class MenuRequestDto
    {
        public Guid StoreId { get; set; }
        public MenuType MenuType { get; set; }
        public int Order { get; set; }
        public Guid MenuIconId { get; set; }
        public string Url { get; set; }
        public Guid PostId { get; set; }
        public Guid PostCategoryId { get; set; }
        public Guid ProductId { get; set; }
        public List<MenuLocalizationDto>? Localizations { get; set; }
    }
    public class MenuLocalizationDto
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
