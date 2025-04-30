using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.StoretSettings.Settings;

namespace MarketPlace.Dto.StoretSettings.Settings
{
    public class StoreAddressResponseDto
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
        public List<StoreAddressLocalizationDto>? Localizations { get; set; } = new();
    }
}
