using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.Products.ProductTypes;
using MarketPlace.Dto.Products.ProductTypes;

namespace MarketPlace.Application.Services.EntityServices.Products
{
    public interface IVariableProductService
    {
        Task<SingleResponse<VariableProduct>> CreateVariableProduct(VariableProductRequestDto input, CancellationToken cancellationToken);
    }
}
