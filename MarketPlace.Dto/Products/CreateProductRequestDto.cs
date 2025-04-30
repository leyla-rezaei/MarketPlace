using MarketPlace.Dto.Contents;
using MarketPlace.Dto.Products.ProductTypes;

namespace MarketPlace.Dto.Products;

public class CreateProductRequestDto
{
    public ProductRequestDto ProductRequestDto { get; set; }

    public decimal SalePrice { get; set; }

    public ProductContentRequestDto ProductContentRequestDto { get; set; }

    public List<DownloadableFileRequestDto>? DownloadableFileRequestDto { get; set; }

    public List<Guid>? CategoryIds { get; set; }

    public List<Guid>? TagIds { get; set; }
}
