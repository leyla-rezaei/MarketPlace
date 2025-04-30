using MarketPlace.Domain.Enums.Product;

namespace MarketPlace.Dto.Products
{
    public class BrandResponseDto
    {

        public Guid Id { get; set; }
        public bool IsApproved { get; set; }
        public bool IsActive { get; set; }
        public BrandType BrandType { get; set; }
        public string RegistrationUrl { get; set; }
        public Guid LogoId { get; set; }
        public List<BrandLocalizationDto>? Localizations { get; set; } = new();
    }


}