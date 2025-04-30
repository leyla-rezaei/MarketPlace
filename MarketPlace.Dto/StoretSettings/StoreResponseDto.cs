using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Media;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Domain.Enums.StoreSetting;

namespace MarketPlace.Dto.StoretSettings
{
    public class StoreResponseDto
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }
        public Guid StoreIconId { get; set; } 
        public string Domain { get; set; }
        public Guid StoreTypeId { get; set; }
        public StoreType StoreType { get; set; }
        public StoreActivationStatus ActivationStatus { get; set; }
        public List<StoreLocalizationDto>? Localizations { get; set; } = new();

    }
}
