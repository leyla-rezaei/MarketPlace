using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Products;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Entities.Products.ProductTypes;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Products.ProductTypes;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.Products.ProductTypes
{
    public class VariableProductService : BaseService<VariableProduct, VariableProductRequestDto, VariableProductResponseDto>, IVariableProductService
    {

        public VariableProductService(IBaseRepository<VariableProduct> repository) : base(repository)
        { }


        public async Task<SingleResponse<VariableProduct>> CreateVariableProduct(VariableProductRequestDto input, CancellationToken cancellationToken)
        {

            var isProductExist = await GetAllAsNoTracking<Product>().Where(x => x.Id == input.ProductId).AnyAsync(cancellationToken);
            if (!isProductExist) return ResponseStatus.NotFound;

            var isDownloadableFileExist = await GetAllAsNoTracking<DownloadableFile>().Where(x => x.Id == input.DownloadableFileId).AnyAsync(cancellationToken);
            if (!isDownloadableFileExist) return ResponseStatus.NotFound;

            var isShippingClassExist = await GetAllAsNoTracking<ShippingClass>().Where(x => x.Id == input.ShippingClassId).AnyAsync(cancellationToken);
            if (!isShippingClassExist) return ResponseStatus.NotFound;

            return await CreateVariableProduct(input, cancellationToken);
        }
    }
}
