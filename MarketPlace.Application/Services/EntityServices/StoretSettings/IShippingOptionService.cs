using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;
using MarketPlace.Dto.StoretSettings.Shippings;

namespace MarketPlace.Application.Services.EntityServices.StoretSettings
{
    public interface IShippingOptionService
    {
        Task<SingleResponse<ShippingOption>> CreateShippingOption(ShippingOptionRequestDto input, CancellationToken cancellationToken);
    }
}
