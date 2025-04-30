using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings.Settings;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.StoretSettings.Settings;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.StoretSettings.Settings
{
    public class StoreDiscussionSettingService : BaseService<StoreDiscussionSetting, StoreDiscussionSettingRequestDto, StoreDiscussionSettingResponseDto>, IStoreDiscussionSettingService
    {
        private readonly IValidator<StoreDiscussionSettingRequestDto> _storeDiscussionSettingValidator;
        public StoreDiscussionSettingService(IBaseRepository<StoreDiscussionSetting> repository,
            IValidator<StoreDiscussionSettingRequestDto> storeDiscussionSettingValidator) : base(repository)
        {
            _storeDiscussionSettingValidator = storeDiscussionSettingValidator;
        }

        public async Task<SingleResponse<StoreDiscussionSetting>> CreateStoreDiscussionSetting(StoreDiscussionSettingRequestDto input, CancellationToken cancellationToken)
        {
            var storeDiscussionSettingValidation = _storeDiscussionSettingValidator.Validate(input).GetAllErrorsString();
            if (storeDiscussionSettingValidation.HasValue()) return (ResponseStatus.ValidationFailed, storeDiscussionSettingValidation);

            var isStoreExist = await GetAllAsNoTracking<Store>().Where(x => x.Id == input.StoreId).AnyAsync(cancellationToken);
            if (!isStoreExist) return ResponseStatus.NotFound;

            return await CreateStoreDiscussionSetting(input, cancellationToken);
        }
    }
}