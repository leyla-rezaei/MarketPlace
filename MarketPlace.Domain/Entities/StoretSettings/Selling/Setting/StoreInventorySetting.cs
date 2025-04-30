using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Selling.Setting;

[Table(nameof(StoreInventorySetting), Schema = nameof(SchemaConsts.selling_setting))]
public class StoreInventorySetting : BaseEntity
{
    //TODO only one setting per store
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
