using MarketPlace.Domain.Entities.StoretSettings;

namespace MarketPlace.Dto.StoretSettings.Users
{
    public class StoreGroupResponseDto
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }

        public List<StoreGroupLocalizationDto>? Localizations { get; set; } = new();
    }
}