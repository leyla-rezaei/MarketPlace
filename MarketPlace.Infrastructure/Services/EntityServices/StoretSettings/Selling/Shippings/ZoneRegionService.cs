using MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.StoretSettings.Shippings;
using MarketPlace.Infrastructure.Services.EntityServices.Common;


namespace MarketPlace.Infrastructure.Services.EntityServices.StoretSettings.Selling.Shippings
{
    public class ZoneRegionService : BaseService<ZoneRegion, ZoneRegionRequestDto, ZoneRegionResponseDto>
    {
        public ZoneRegionService(IBaseRepository<ZoneRegion> repository) : base(repository)
        { }

    }
}
