using MarketPlace.Domain.Entities.Products;

namespace MarketPlace.Dto.Products.ProductTypes
{
    public class DownloadableFileResponseDto
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public string FileUrl { get; set; }

        public List<DownloadableFileLocalizationDto>? Localizations { get; set; } = new();
    }
}
