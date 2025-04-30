using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.StoretSettings.Shippings;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.StoretSettings.Selling.Shippings
{
    public class ShippnigZoneService : BaseService<ShippingZone, ShippingZoneRequestDto, ShippingZoneResponseDto>, IShippnigZoneService
    {
        private readonly IValidator<ShippingZoneRequestDto> _shippingZoneValidator;
        public ShippnigZoneService(IBaseRepository<ShippingZone> repository,
            IValidator<ShippingZoneRequestDto> shippingZoneValidator) : base(repository)
        {
            _shippingZoneValidator = shippingZoneValidator;
        }
        public async Task<SingleResponse<ShippingZone>> CreateShippingZone(ShippingZoneRequestDto input, CancellationToken cancellationToken)
        {
            var shippingZoneValidation = _shippingZoneValidator.Validate(input).GetAllErrorsString();
            if (shippingZoneValidation.HasValue()) return (ResponseStatus.ValidationFailed, shippingZoneValidation);

            var isZoneRegionExist = await GetAllAsNoTracking<ZoneRegion>().Where(x => x.Id == input.ZoneRegionId).AnyAsync(cancellationToken);
            if (!isZoneRegionExist) return ResponseStatus.NotFound;

            return await CreateShippingZone(input, cancellationToken);
        }
    }
}