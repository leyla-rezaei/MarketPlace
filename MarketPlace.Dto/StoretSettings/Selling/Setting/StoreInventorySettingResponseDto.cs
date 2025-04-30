using MarketPlace.Domain.Entities.StoretSettings;

namespace MarketPlace.Dto.StoretSettings.Selling.Setting
{
    public class StoreInventorySettingResponseDto
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public bool IsEnableStockManagement { get; set; }
        public int HoldStockInMinutes { get; set; }
        public bool IsLowStockNotificationsEnable { get; set; }
        public bool IsOutOfStockNotificationsEnable { get; set; }
        public string NotificationRecipientEmail { get; set; }
        public int LowStockThreshold { get; set; }
        public int OutOfStockThreshold { get; set; }
        public int IsOutOfStockHideFromCatalog { get; set; }
    }
}
