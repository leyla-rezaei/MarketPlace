using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Media;
using MarketPlace.Domain.Enums.Product;

namespace MarketPlace.Domain.Entities.Products;

public class Brand : BaseEntity
{
    public bool IsApproved { get; set; }
    public bool IsActive { get; set; }
        
    public BrandType BrandType { get; set; }
    public string? RegistrationUrl { get; set; }

    public Guid LogoId { get; set; }
    public MultiMediaFile Logo { get; set; }


    //Navigation properties
    public ICollection<Product> Products { get; set; }
    public ICollection<BrandLocalization> Localizations { get; set; }

}
