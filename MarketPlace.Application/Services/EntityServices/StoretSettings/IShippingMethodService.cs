using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;
using MarketPlace.Dto.StoretSettings.Shippings;

namespace MarketPlace.Application.Services.EntityServices.StoretSettings
{
    public interface IShippingMethodService :IBaseService<ShippingMethod, ShippingMethodRequestDto, ShippingMethodResponseDto>
    {
        Task<SingleResponse<ShippingMethod>> CreateShippingMethod(ShippingMethodRequestDto input, CancellationToken cancellationToken);
    }
}
