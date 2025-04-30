using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Products;
using MarketPlace.Domain.Entities.Orders.ShoppingCards;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Entities.Products.Pricing;
using MarketPlace.Domain.Entities.Products.ProductTypes;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Products.Pricing;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;


namespace MarketPlace.Infrastructure.Services.EntityServices.Products.Pricing
{
    public class DiscountPriceService : BaseService<DiscountPrice, DiscountPriceRequestDto, DiscountPriceResponseDto>, IDiscountPriceService
    {
        private readonly IValidator<DiscountPriceRequestDto> _discountPriceValidator;
        private readonly IProductService _productService;

        public DiscountPriceService(IBaseRepository<DiscountPrice> repository,
        IValidator<DiscountPriceRequestDto> discountPriceValidator,
        IProductService productService) : base(repository)
        {
            _discountPriceValidator = discountPriceValidator;
            _productService = productService;
        }

        public async Task<SingleResponse<DiscountPrice>> CreateDiscountPriceService(DiscountPriceRequestDto input, CancellationToken cancellationToken)
        {
            //check discountPrice validation then create it
            var discountPriceValidation = _discountPriceValidator.Validate(input).GetAllErrorsString();
            if (discountPriceValidation.HasValue()) return (ResponseStatus.ValidationFailed, discountPriceValidation);

            var isProductExist = await GetAllAsNoTracking<Product>().Where(x => x.Id == input.ProductId).AnyAsync(cancellationToken);
            if (!isProductExist) return ResponseStatus.NotFound;

            var isVariableProductExist = await GetAllAsNoTracking<VariableProduct>().Where(x => x.Id == input.VariableProductId).AnyAsync(cancellationToken);
            if (!isVariableProductExist) return ResponseStatus.NotFound;

            return await Create(input, cancellationToken);
        }

        public async Task<SingleResponse<DiscountPriceResponseDto>> GetDiscountPriceByProductId(Guid productId, CancellationToken cancellationToken)
        {
            var product = await GetAllAsNoTracking<Product>()
                .Where(x => x.Id == productId)
                .FirstOrDefaultAsync(cancellationToken);

            if (product is null) return ResponseStatus.NotFound;

            var discountPrice = await base.GetAllAsNoTracking()
            .Where(discountPrice => discountPrice.ProductId == productId)
            .Select(discountPrice => new DiscountPriceResponseDto
            {
                Id = discountPrice.Id,
                Product = discountPrice.Product,
                SalePrice = discountPrice.SalePrice,
                SalePriceFrom = discountPrice.SalePriceFrom,
                SalePriceTo = discountPrice.SalePriceTo,
                VariableProduct = discountPrice.VariableProduct
            }).FirstOrDefaultAsync(cancellationToken);

            return discountPrice;
        }
    }
}
