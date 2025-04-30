using MarketPlace.Domain.Enums.Product;
using MarketPlace.Domain.Enums;

namespace MarketPlace.Dto.Products;

public class ProductRequestDto
{
    public Guid StoreId { get; set; }

    public ProductType ProductType { get; set; }
    public Guid BrandId { get; set; }

    public bool IsOrginalProduct { get; set; }
    public string GeneralCode { get; set; }
    public PublishStatus PublishStatus { get; set; }
    public Visibility Visibility { get; set; }
    public string Password { get; set; }
    public bool IsSchedulingPublish { get; set; }
    public DateTimeOffset PublishOn { get; set; }
    public CatalogVisibility CatalogVisibility { get; set; }
    public ProductSellingUnit ProductSellingUnit { get; set; }
    public bool IsInstallmentEnabled { get; set; }
    public decimal PackingLength { get; set; }
    public decimal PackingWidth { get; set; }
    public decimal PackingHeight { get; set; }
    public decimal ProductLength { get; set; }
    public decimal ProductWidth { get; set; }
    public decimal ProductHeight { get; set; }
    public string SerialNumber { get; set; }
    public bool IsManageStock { get; set; }
    public StockStatus StockStatus { get; set; }
    public uint StockQuantity { get; set; }
    public AllowBackordersStatus AllowBackordersStatus { get; set; }
    public uint LowStockThreshold { get; set; }
    public Guid ShippingClassId { get; set; }
    public uint MenuOrder { get; set; }
    public bool IsCommentsAllowed { get; set; }

    public List<ProductLocalizationDto>? Localizations {  get; set; }


    public class ProductLocalizationDto
    {
        public string Key { get; set; }
        public string PurchaseNote { get; set; }
        public string PackingDescription { get; set; }
    }
}
