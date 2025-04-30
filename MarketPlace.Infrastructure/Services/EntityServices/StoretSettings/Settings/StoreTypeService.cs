using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.StoretSettings.Settings;
using MarketPlace.Infrastructure.Services.EntityServices.Common;

namespace MarketPlace.Infrastructure.Services.EntityServices.StoretSettings.Settings
{
    public class StoreTypeService : BaseService<StoreType, StoreTypeRequestDto, StoreTypeResponseDto>
    {
        public StoreTypeService(IBaseRepository<StoreType> repository) : base(repository)
        {
        }
    }
}