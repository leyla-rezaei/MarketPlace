using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.StoretSettings.Settings;

namespace MarketPlace.Application.Services.EntityServices.StoretSettings.Settings
{
    public interface IStoreAddressService
    {
        Task<SingleResponse<StoreAddress>> CreateStoreAddress(StoreAddressRequestDto input, CancellationToken cancellationToken);
    }
}