using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.Products.ProductTypes;
using MarketPlace.Dto.Products.ProductTypes;


namespace MarketPlace.Application.Services.EntityServices.Products
{
    public interface IDownloadableFileService
    {
        Task<SingleResponse<DownloadableFile>> CreateDownloadableFile(DownloadableFileRequestDto input, CancellationToken cancellationToken);
    }
}
