using MarketPlace.Domain.Entities.Categories;
using MarketPlace.Domain.Entities.Comments;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Contents;
using MarketPlace.Domain.Entities.Media;
using MarketPlace.Domain.Entities.Orders.ShoppingCards;
using MarketPlace.Domain.Entities.Products.Pricing;
using MarketPlace.Domain.Entities.Products.ProductTypes;
using MarketPlace.Domain.Entities.Rates;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Promotions;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;
using MarketPlace.Domain.Enums;
using MarketPlace.Domain.Enums.Product;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Products;

[Table(nameof(Product), Schema = nameof(SchemaConsts.product))]
public class Product : BaseEntity
{
    #region Required
    public Guid StoreId { get; set; }
    public Store Store { get; set; }

    public ProductType ProductType { get; set; }
    #endregion

    public Guid? BrandId { get; set; }
    public Brand Brand { get; set; }

    public bool IsOrginalProduct { get; set; }

    //TODO this code is generated outomatically contain 3 letters and 7 digit and it should be unique
    public string GeneralCode { get; set; }

    #region ProductPage
    public PublishStatus PublishStatus { get; set; }
    public Visibility Visibility { get; set; }
    public string? Password { get; set; }
    public bool IsSchedulingPublish { get; set; }
    public DateTimeOffset? PublishOn { get; set; }
    public CatalogVisibility CatalogVisibility { get; set; }
    #endregion
    public ProductSellingUnit ProductSellingUnit { get; set; }
    public bool IsInstallmentEnabled { get; set; }

    #region Product Size
    public decimal? PackingLength { get; set; }
    public decimal? PackingWidth { get; set; }
    public decimal? PackingHeight { get; set; }

    public decimal? ProductLength { get; set; }
    public decimal? ProductWidth { get; set; }
    public decimal? ProductHeight { get; set; }
    #endregion

    #region Inventory
    public string SerialNumber { get; set; }
    public bool IsManageStock { get; set; }
    public StockStatus StockStatus { get; set; }
    public uint? StockQuantity { get; set; }
    public AllowBackordersStatus AllowBackordersStatus { get; set; }
    public uint LowStockThreshold { get; set; }
    #endregion

    #region Shipping
    public Guid? ShippingClassId { get; set; }
    public ShippingClass ShippingClass { get; set; }
    #endregion

    #region Advanced
    public uint? MenuOrder { get; set; }
    public bool IsCommentsAllowed { get; set; }
    #endregion

    #region Counting
    public byte TotalRate { get; set; }
    public uint SelledQuantity { get; set; }
    public uint CommentCount { get; set; }
    public uint ViewCount { get; set; }
    #endregion

    #region Navigation Properties
    public ICollection<ProductRate> ProductRates { get; set; }
    public ICollection<DiscountPrice> DiscountPrices { get; set; }
    public ICollection<Price> Prices { get; set; }
    public ICollection<ProductComment> ProductComments { get; set; }
    public ICollection<ProductContent> ProductContents { get; set; }
    public ICollection<ProductMultiMedia> ProductGalleries { get; set; }
    public ICollection<ShoppingCardDetail> ShoppingCardDetails { get; set; }
    public ICollection<DownloadableFile> DownloadableFiles { get; set; }
    public ICollection<ProductCategory> ProductCategories { get; set; }
    public ICollection<Coupon> Coupons { get; set; }
    public ICollection<VariableProduct> VariableProducts { get; set; }
    public ICollection<ProductLocalization> Localizations { get; set; }

    #endregion
}
