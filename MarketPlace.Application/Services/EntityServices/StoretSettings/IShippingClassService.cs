using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;
using MarketPlace.Dto.StoretSettings.Shippings;

namespace MarketPlace.Application.Services.EntityServices.StoretSettings
{
    public interface IShippingClassService : IBaseService<ShippingClass, ShippingClassRequestDto, ShippingClassResponseDto>
    {
        Task<SingleResponse<ShippingClass>> CreateShippingClass(ShippingClassRequestDto input, CancellationToken cancellationToken);
        Task<SingleResponse<ShippingClassResponseDto>> GetShippingClassesById(Guid productId, CancellationToken cancellationToken);
    }
}
