namespace MarketPlace.Dto.StoretSettings.Selling.Setting
{
    public class StoreInventorySettingRequestDto
    {
        public Guid StoreId { get; set; }
        public bool IsEnableStockManagement { get; set; }
        public int HoldStockInMinutes { get; set; }
        public bool IsLowStockNotificationsEnable { get; set; }
        public bool IsOutOfStockNotificationsEnable { get; set; }
        public string? NotificationRecipientEmail { get; set; }
        public int LowStockThreshold { get; set; }
        public int OutOfStockThreshold { get; set; }
        public int IsOutOfStockHideFromCatalog { get; set; }
    }
}