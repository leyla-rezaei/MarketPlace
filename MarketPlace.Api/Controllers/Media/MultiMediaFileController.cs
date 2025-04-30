using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.MultiMediaFiles;
using MarketPlace.Domain.Entities.Media;
using MarketPlace.Dto.Media;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.Media
{
    public class MultiMediaFileController : BaseController<MultiMediaFile, MultiMediaFileRequestDto, MultiMediaFileResponseDto>
    {
        private readonly IMultiMediaFileService _service;
        public MultiMediaFileController(IMultiMediaFileService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<MultiMediaFile>> SaveMedia(IFormFile file, MultiMediaFileRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.SaveMedia(file, input, cancellationToken);
        }

        [HttpDelete("[action]")]
        public async Task<SingleResponse<bool>> Delete(MultiMediaFileRequestDto input)
        {
            return await _service.Delete(input);
        }

        [HttpGet("[action]/{productId}")]
        public async Task<SingleResponse<MultiMediaFileResponseDto>> GetProductMediaFile([FromRoute] Guid productId, CancellationToken cancellationToken)
        {
            return await _service.GetProductMediaFile(productId, cancellationToken);
        }
    }
}