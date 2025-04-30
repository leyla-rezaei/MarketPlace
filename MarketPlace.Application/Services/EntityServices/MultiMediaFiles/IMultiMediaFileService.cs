using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.Media;
using MarketPlace.Dto.Media;
using Microsoft.AspNetCore.Http;

namespace MarketPlace.Application.Services.EntityServices.MultiMediaFiles
{
    public interface IMultiMediaFileService : IBaseService<MultiMediaFile, MultiMediaFileRequestDto, MultiMediaFileResponseDto>
    {
        Task<SingleResponse<MultiMediaFile>> SaveMedia(IFormFile file, MultiMediaFileRequestDto input,CancellationToken cancellationToken);
        Task<SingleResponse<bool>> Delete(MultiMediaFileRequestDto input);
        Task<SingleResponse<MultiMediaFileResponseDto>> GetProductMediaFile(Guid productId, CancellationToken cancellationToken);
    }
}