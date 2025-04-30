using MarketPlace.Domain.Enums.Product;

namespace MarketPlace.Dto.Products;

public class BrandSummaryResponseDto
{
    public Guid Id { get; set; }
    public bool IsApproved { get; set; }
    public bool IsActive { get; set; }
    public BrandType BrandType { get; set; }
    public string RegistrationUrl { get; set; }
    public Guid LogoId { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
}
