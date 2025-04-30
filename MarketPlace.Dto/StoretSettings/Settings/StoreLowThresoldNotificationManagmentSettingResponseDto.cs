using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Enums.Selling;

namespace MarketPlace.Dto.StoretSettings.Settings
{
    public class StoreLowThresoldNotificationManagmentSettingResponseDto
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public uint LowThresoldLimit { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
