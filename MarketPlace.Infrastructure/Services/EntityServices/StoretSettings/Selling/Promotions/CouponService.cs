using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Products;
using MarketPlace.Application.Services.EntityServices.StoretSettings;
using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Promotions;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.StoretSettings.Selling.Promotions;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;


namespace MarketPlace.Infrastructure.Services.EntityServices.StoretSettings.Selling.Promotions
{
    public class CouponService : BaseService<Coupon, CouponRequestDto, CouponResponseDto>, ICouponService
    {
        private readonly IValidator<CouponRequestDto> _couponValidator;
        private readonly IProductService _productService;

        public CouponService(IBaseRepository<Coupon> repository,
            IValidator<CouponRequestDto> couponValidator,
            IProductService productService) : base(repository)
        {
            _couponValidator = couponValidator;
            _productService = productService;
        }

        public async Task<SingleResponse<Coupon>> CreateCoupon(CouponRequestDto input, CancellationToken cancellationToken)
        {
            var couponValidation = _couponValidator.Validate(input).GetAllErrorsString();
            if (couponValidation.HasValue()) return (ResponseStatus.ValidationFailed, couponValidation);

            var isStoreExist = await GetAllAsNoTracking<Store>().Where(x => x.Id == input.StoreId).AnyAsync(cancellationToken);
            if (!isStoreExist) return ResponseStatus.NotFound;

            var isUserExist = await GetAllAsNoTracking<User>().Where(x => x.Id == input.UserId).AnyAsync(cancellationToken);
            if (!isUserExist) return ResponseStatus.NotFound;

            var isProductExist = await GetAllAsNoTracking<Product>().Where(x => x.Id == input.ProductId).AnyAsync(cancellationToken);
            if (!isProductExist) return ResponseStatus.NotFound;

            return await CreateCoupon(input, cancellationToken);
        }

        public async Task<SingleResponse<CouponResponseDto>> GetCouponByProductId(Guid productId, CancellationToken cancellationToken)
        {
            var product = await GetAllAsNoTracking<Product>()
                .Where(x => x.Id == productId)
                .FirstOrDefaultAsync(cancellationToken);

            if (product is null) return ResponseStatus.NotFound;

            var coupon = await base.GetAllAsNoTracking()
                  .Where(coupon => coupon.ProductId == productId)
                  .Select(coupon => new CouponResponseDto
                  {
                      Code = coupon.Code,
                      DiscountType = coupon.DiscountType,
                      Id = coupon.Id,
                      MaxInvoiceLimit = coupon.MaxInvoiceLimit,
                      MinInvoiceLimit = coupon.MinInvoiceLimit,
                      Percent = coupon.Percent,
                      Product = coupon.Product,
                      Store = coupon.Store,
                      UsableCount = coupon.UsableCount,
                      Usage = coupon.Usage,
                      User = coupon.User,
                      ValidFrom = coupon.ValidFrom,
                      ValidTo = coupon.ValidTo,
                      Localizations = coupon.Localizations
                      .Select(x => new CouponLocalizationDto
                      {
                          Description = x.Description
                          ,
                          Key = x.Key
                      }).ToList(),

                  }).FirstOrDefaultAsync(cancellationToken);

            return coupon;
        }
    }
}