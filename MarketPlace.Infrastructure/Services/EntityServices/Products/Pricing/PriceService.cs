using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Products;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Entities.Products.Pricing;
using MarketPlace.Domain.Entities.Products.ProductTypes;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Products.Pricing;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.Products.Pricing
{
    public class PriceService : BaseService<Price, PriceRequestDto, PriceResponseDto>, IPriceService
    {
        private readonly IValidator<PriceRequestDto> _priceValidator;
        private readonly IProductService _productService;

        public PriceService(IBaseRepository<Price> repository, IValidator<PriceRequestDto> priceValidator,
          IProductService productService) : base(repository)
        {
            _priceValidator = priceValidator;
            _productService = productService;
        }

        public async Task<SingleResponse<Price>> CreatePrice(PriceRequestDto input, CancellationToken cancellationToken)
        {
            //check price validation then create it
            var priceValidation = _priceValidator.Validate(input).GetAllErrorsString();
            if (priceValidation.HasValue()) return (ResponseStatus.ValidationFailed, priceValidation);

            var isProductExist = await GetAllAsNoTracking<Product>().Where(x => x.Id == input.ProductId).AnyAsync(cancellationToken);
            if (!isProductExist) return ResponseStatus.NotFound;

            var isVariableProductExist = await GetAllAsNoTracking<VariableProduct>().Where(x => x.Id == input.VariableProductId).AnyAsync(cancellationToken);
            if (!isVariableProductExist) return ResponseStatus.NotFound;

            return await CreatePrice(input, cancellationToken);
        }

        public async Task<SingleResponse<PriceResponseDto>> GetPriceByProductId(Guid productId, CancellationToken cancellationToken)
        {
            var product = await GetAllAsNoTracking<Product>()
                .Where(x => x.Id == productId)
                .FirstOrDefaultAsync(cancellationToken);

            if (product is null) return ResponseStatus.NotFound;

                var price = await base.GetAllAsNoTracking()
                    .Where(price => price.ProductId == productId)
                    .Select(price => new PriceResponseDto
                    {
                        Id = price.Id,
                        VariableProduct = price.VariableProduct,
                        SalePrice = price.SalePrice,
                        Product = price.Product
                    }).FirstOrDefaultAsync(cancellationToken);
                return price;
            }  
        }
    }
