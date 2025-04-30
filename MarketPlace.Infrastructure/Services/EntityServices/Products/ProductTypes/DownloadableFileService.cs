using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Products;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Entities.Products.ProductTypes;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Products.ProductTypes;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.Products.ProductTypes
{
    public class DownloadableFileService : BaseService<DownloadableFile, DownloadableFileRequestDto, DownloadableFileResponseDto>, IDownloadableFileService
    {
        private readonly IValidator<DownloadableFileRequestDto> _downloadableFileValidator;
        public DownloadableFileService(IBaseRepository<DownloadableFile> repository,
            IValidator<DownloadableFileRequestDto> downloadableFileValidator) : base(repository)
        { 
            _downloadableFileValidator = downloadableFileValidator;
        }

        public  async Task<SingleResponse<DownloadableFile>> CreateDownloadableFile(DownloadableFileRequestDto input, CancellationToken cancellationToken)
        {
            var productDownloadableFileValidation = _downloadableFileValidator.Validate(input).GetAllErrorsString();
            if(productDownloadableFileValidation.HasValue()) return (ResponseStatus.ValidationFailed, productDownloadableFileValidation);

            var isProductExist = await GetAllAsNoTracking<Product>().Where(x => x.Id == input.ProductId).AnyAsync(cancellationToken);
            if (!isProductExist) return ResponseStatus.NotFound;

            return await CreateDownloadableFile(input, cancellationToken);
        }
    }
}
