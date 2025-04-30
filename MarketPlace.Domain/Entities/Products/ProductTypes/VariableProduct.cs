using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Products.ProductTypes;

[Table(nameof(VariableProduct), Schema = nameof(SchemaConsts.product))]
public class VariableProduct : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public bool IsEnabled { get; set; }

    public Guid? DownloadableFileId { get; set; }
    public DownloadableFile DownloadableFile { get; set; }

    public bool IsManageStock { get; set; }


    #region General
    public Guid ShippingClassId { get; set; }
    public ShippingClass ShippingClass { get; set; }

    #endregion

    #region Navigation proerties
    public ICollection<DownloadableFile> DownloadableFiles { get; set; }
    public ICollection<VariableProductLocalization> Localizations { get; set; }
    #endregion

}
