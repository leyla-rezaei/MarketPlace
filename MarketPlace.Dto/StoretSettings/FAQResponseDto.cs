using MarketPlace.Domain.Entities.StoretSettings;

namespace MarketPlace.Dto.StoretSettings
{
    public class FAQResponseDto
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public int Order { get; set; }
        public List<FAQLocalizationDto>? Localizations { get; set; } = new();
    }
}
