using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Products;
using MarketPlace.Domain.Entities.Products.ProductTypes;
using MarketPlace.Dto.Products.ProductTypes;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.Products.ProductTypes
{
    public class DownloadableFileController : ControllerBase
    {
        private readonly IDownloadableFileService _service;
        public DownloadableFileController(IDownloadableFileService service) 
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<DownloadableFile>> CreateDownloadableFile(DownloadableFileRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateDownloadableFile(input, cancellationToken);
        }
    }
}