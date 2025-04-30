using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Products;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Entities.Products.Installment;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Products.Installment;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.Products.Installment
{
    public class ProductInstallmentService : BaseService<ProductInstallment, ProductInstallmentRequestDto, ProductInstallmentResponseDto>, IProductInstallmentService
    {
        private readonly IValidator<ProductInstallmentRequestDto> _productInstallmentovalidator;
        private readonly IProductService _productService;
        public ProductInstallmentService(IBaseRepository<ProductInstallment> repository,
            IValidator<ProductInstallmentRequestDto> productInstallmentvalidator,
            IProductService productService) : base(repository)
        {
            _productInstallmentovalidator = productInstallmentvalidator;
            _productService = productService;
        }


        public async Task<SingleResponse<ProductInstallment>> CreateProductInstallment(ProductInstallmentRequestDto input, CancellationToken cancellationToken)
        {
            var productInstallmentValidation = _productInstallmentovalidator
                .Validate(input).GetAllErrorsString();
            if (productInstallmentValidation.HasValue()) return (ResponseStatus.ValidationFailed, productInstallmentValidation);

            var isProductExist = await GetAllAsNoTracking<Product>().Where(x => x.Id == input.ProductId).AnyAsync(cancellationToken);
            if (!isProductExist) return ResponseStatus.NotFound;

            return await CreateProductInstallment(input, cancellationToken);
        }

        public async Task<ListResponse<ProductInstallmentResponseDto>> GetProductInstallmentsByProductId(Guid productId, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProduct(productId, cancellationToken);

            if (product != null)
            {
                var productInstallments = await base.GetAllAsNoTracking()
                    .Where(productInstallment => productInstallment.ProductId == productId)
                    .Select(productInstallment => new ProductInstallmentResponseDto
                    {
                        BenefitPercent = productInstallment.BenefitPercent,
                        Id = productInstallment.Id,
                        NumberOfInstallment = productInstallment.NumberOfInstallment,
                        Product = productInstallment.Product
                    }).ToListAsync();

                return productInstallments;
            }
            else
            {
                return new List<ProductInstallmentResponseDto>();
            }
        }
    }
}
