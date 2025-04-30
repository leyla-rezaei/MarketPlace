using MarketPlace.Domain.Enums.Product;

namespace MarketPlace.Dto.Products
{
    public class BrandRequestDto
    {
        public bool IsApproved { get; set; }
        public bool IsActive { get; set; }
        public BrandType BrandType { get; set; }
        public string RegistrationUrl { get; set; }
        public Guid LogoId { get; set; }
        public List<BrandLocalizationDto>? Localizations { get; set; }
    }

    public class BrandLocalizationDto
    {
        public string Key { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}