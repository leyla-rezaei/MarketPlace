using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Entities.Products.ProductTypes;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;

namespace MarketPlace.Dto.Products.ProductTypes
{
    public class VariableProductResponseDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public bool IsEnabled { get; set; }
        public Guid DownloadableFileId { get; set; }
        public DownloadableFile DownloadableFile { get; set; }
        public bool IsManageStock { get; set; }
        public Guid ShippingClassId { get; set; }
        public ShippingClass ShippingClass { get; set; }

        public List<VariableProductLocalizationDto>? Localizations { get; set; } = new();
    }
}
