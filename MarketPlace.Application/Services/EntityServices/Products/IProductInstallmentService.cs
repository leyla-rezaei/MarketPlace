using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.Products.Installment;
using MarketPlace.Dto.Products.Installment;

namespace MarketPlace.Application.Services.EntityServices.Products
{
    public interface IProductInstallmentService : IBaseService<ProductInstallment,ProductInstallmentRequestDto,ProductInstallmentResponseDto>
    {
        Task<SingleResponse<ProductInstallment>> CreateProductInstallment(ProductInstallmentRequestDto input, CancellationToken cancellationToken);
        Task<ListResponse<ProductInstallmentResponseDto>> GetProductInstallmentsByProductId(Guid productId, CancellationToken cancellationToken);
    }
}
