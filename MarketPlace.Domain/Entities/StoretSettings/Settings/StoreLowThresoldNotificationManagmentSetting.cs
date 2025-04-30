using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Enums.Selling;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Settings;

[Table(nameof(StoreLowThresoldNotificationManagmentSetting), Schema = nameof(SchemaConsts.store_setting))]
public class StoreLowThresoldNotificationManagmentSetting : BaseEntity
{
    public Guid StoreId { get; set; }
    public Store Store { get; set; }

    public uint LowThresoldLimit { get; set; }
    public NotificationType NotificationType { get; set; }
}
