using MarketPlace.Domain.Enums.Selling;

namespace MarketPlace.Dto.StoretSettings.Settings
{
    public class StoreLowThresoldNotificationManagmentSettingRequestDto
    {
        public Guid StoreId { get; set; }
        public uint LowThresoldLimit { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
