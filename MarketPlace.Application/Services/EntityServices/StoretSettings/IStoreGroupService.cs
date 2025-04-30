using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.StoretSettings.Users;
using MarketPlace.Dto.StoretSettings.Users;

namespace MarketPlace.Application.Services.EntityServices.StoretSettings
{
    public interface IStoreGroupService
    {
        Task<SingleResponse<StoreGroup>> CreateStoreGroup(StoreGroupRequestDto input, CancellationToken cancellationToken);
    }
}
