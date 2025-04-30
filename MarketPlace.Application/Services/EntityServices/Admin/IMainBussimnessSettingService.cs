using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.Admin;
using MarketPlace.Dto.Admin;

namespace MarketPlace.Application.Services.EntityServices.Admin
{
    public interface IMainBussimnessSettingService :IBaseService<MainBusinessSetting, MainBusinessSettingRequestDto, MainBusinessSettingResponseDto>
    {
        Task<SingleResponse<MainBusinessSetting>> CreateMainBusinessSetting(MainBusinessSettingRequestDto input, CancellationToken cancellationToken);
        Task<SingleResponse<MainBusinessSetting>> UpdateMainBusinessSetting(Guid id, MainBusinessSettingRequestDto input, CancellationToken cancellationToken);
        Task<SingleResponse<bool>> DeleteMainBusinessSetting(Guid id, CancellationToken cancellationToken);
    }
}
   