using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Admin;
using MarketPlace.Domain.Entities.Admin;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Admin;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.Admin
{
    public class MainStoreMediaOptionSettingService : BaseService<MainStoreMediaOptionSetting,MainStoreMediaOptionSettingRequestDto , MainStoreMediaOptionSettingResponseDto>, IMainStoreMediaOptionSettingService
    {
        private readonly IValidator<MainStoreMediaOptionSettingRequestDto> _mainStoreMediaOptionSettingValidator;
        public MainStoreMediaOptionSettingService(IBaseRepository<MainStoreMediaOptionSetting> repository,
            IValidator<MainStoreMediaOptionSettingRequestDto> mainStoreMediaOptionSettingValidator) : base(repository)
        {
            _mainStoreMediaOptionSettingValidator = mainStoreMediaOptionSettingValidator;
        }

        public  async Task<SingleResponse<MainStoreMediaOptionSetting>> UpdateMainStoreMediaOptionSetting(Guid id, MainStoreMediaOptionSettingRequestDto input, CancellationToken cancellationToken)
        {
            var mainStoreMediaOptionSettingValidation = _mainStoreMediaOptionSettingValidator.Validate(input).GetAllErrorsString();
            if (mainStoreMediaOptionSettingValidation.HasValue()) return (ResponseStatus.ValidationFailed, mainStoreMediaOptionSettingValidation);

            var isMainStoreMediaOptionSettingExist = await GetAll().Where(x => x.Id == id).AnyAsync(cancellationToken);
            if (!isMainStoreMediaOptionSettingExist) return ResponseStatus.NotFound;

            return await UpdateMainStoreMediaOptionSetting(id, input, cancellationToken);
        }
    }
}
