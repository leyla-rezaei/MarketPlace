using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.Admin;
using MarketPlace.Dto.Admin;


namespace MarketPlace.Application.Services.EntityServices.Admin
{
    public interface IMainStoreMediaOptionSettingService : IBaseService<MainStoreMediaOptionSetting, MainStoreMediaOptionSettingRequestDto,MainStoreMediaOptionSettingResponseDto>
    {
        Task<SingleResponse<MainStoreMediaOptionSetting>> UpdateMainStoreMediaOptionSetting(Guid id, MainStoreMediaOptionSettingRequestDto input, CancellationToken cancellationToken);
    }
}
