using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;
using MarketPlace.Dto.StoretSettings.Shippings;

namespace MarketPlace.Application.Services.EntityServices.StoretSettings
{
    public interface IShippnigZoneService : IBaseService<ShippingZone, ShippingZoneRequestDto, ShippingZoneResponseDto>
    {
        Task<SingleResponse<ShippingZone>> CreateShippingZone(ShippingZoneRequestDto input, CancellationToken cancellationToken);
    }
}