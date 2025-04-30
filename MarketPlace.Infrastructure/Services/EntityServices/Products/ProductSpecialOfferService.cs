using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Products;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Products;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;


namespace MarketPlace.Infrastructure.Services.EntityServices.Products
{
    public class ProductSpecialOfferService : BaseService<ProductSpecialOffer, ProductSpecialOfferRequestDto, ProductSpecialOfferResponseDto>, IProductSpecialOfferService
    {
        private readonly IValidator<ProductSpecialOfferRequestDto> _productSpecialOfferValidator;
        private readonly IProductService _productService;

        public ProductSpecialOfferService(IBaseRepository<ProductSpecialOffer> repository,
            IValidator<ProductSpecialOfferRequestDto> productSpecialOfferValidator,
           IProductService productService) : base(repository)
        {
            _productSpecialOfferValidator = productSpecialOfferValidator; 
            _productService = productService;
        }

        public  async Task<SingleResponse<ProductSpecialOffer>> CreateProductSpecialOffer(ProductSpecialOfferRequestDto input, CancellationToken cancellationToken)
        {
            var productSpecialOfferValidation = _productSpecialOfferValidator.Validate(input).GetAllErrorsString();
            if (productSpecialOfferValidation.HasValue()) return (ResponseStatus.ValidationFailed, productSpecialOfferValidation);

            var isProductExist = await GetAllAsNoTracking<Product>().Where(x => x.Id == input.ProductId).AnyAsync(cancellationToken);
            if (!isProductExist) return ResponseStatus.NotFound;
            return await CreateProductSpecialOffer(input, cancellationToken);
        }

        public async Task<List<ProductSpecialOfferResponseDto>> GetProductSpecialOffersByProductId(Guid productId, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProduct(productId, cancellationToken);

            if (product != null)
            {
             var productSpecialOffers = await base.GetAllAsNoTracking()
            .Where(productSpecialOffers => productSpecialOffers.ProductId == productId)
            .Select(productSpecialOffer => new ProductSpecialOfferResponseDto
            {
                Expiration = DateTime.UtcNow,
                OfferPrice = productSpecialOffer.OfferPrice,
                Product = productSpecialOffer.Product
            }).ToListAsync();

                return productSpecialOffers;
            }
            else
            {
                return new List<ProductSpecialOfferResponseDto>();
            }
        }
    }
}
