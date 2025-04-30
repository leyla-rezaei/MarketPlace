using MarketPlace.Domain.Enums.StoreSetting;

namespace MarketPlace.Dto.StoretSettings.Settings
{
    public class StoreActivationStatusResponseDto
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public StoreActivationStatus ActivationStatus { get; set; }
    }
}
