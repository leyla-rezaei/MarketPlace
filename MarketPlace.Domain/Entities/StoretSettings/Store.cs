using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Posts;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Media;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Entities.StoretSettings.Selling.PayGateSetting;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Promotions;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Setting;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Domain.Enums.StoreSetting;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings;

[Table(nameof(Store), Schema = nameof(SchemaConsts.store_setting))]
public class Store : BaseEntity
{
    public Guid OwnerId { get; set; }
    public User Owner { get; set; }
    public StoreActivationStatus ActivationStatus { get; set; }
    public Guid StoreTypeId { get; set; }
    public StoreType StoreType { get; set; }
    public Guid StoreIconId { get; set; }
    public MultiMediaFile StoreIcon { get; set; }
    public string Domain { get; set; }

    #region Navigation properties
    public ICollection<FAQ> FAQs { get; set; }
    public ICollection<StoreAdmin> StoreAdmins { get; set; }
    public ICollection<Post> Posts { get; set; }
    public ICollection<Product> Products { get; set; }
    public ICollection<PayPalSetting> PayPalSettings { get; set; }
    public ICollection<ZarinPalSetting> ZarinPalSettings { get; set; }
    public ICollection<Coupon> Coupons { get; set; }
    public ICollection<StoreAddress> StoreAddresses { get; set; }
    public ICollection<ShippingClass> ShippingClasses { get; set; }
    public ICollection<ShippingOption> ShippingOptions { get; set; }
    public ICollection<StoreGeneralSetting> GeneralSettings { get; set; }
    public ICollection<StoreDiscussionSetting> StoreDiscussionSettings { get; set; }
    public ICollection<StoreGeneralSellingSettings> StoreGeneralSellingSettings { get; set; }
    public ICollection<StoreMediaOptionSetting> StoreMediaOptions { get; set; }
    public ICollection<StoreWritingSetting> StoreWritingSettings { get; set; }
    public ICollection<StoreReadingSetting> StoreReadingSettings { get; set; }
    public ICollection<StoreInventorySetting> StoreInventorySettings { get; set; }
    public ICollection<StoreLocalization> Localizations {  get; set; }
    #endregion
}
