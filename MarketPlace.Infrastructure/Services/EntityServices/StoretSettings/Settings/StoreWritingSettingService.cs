using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings.Settings;
using MarketPlace.Domain.Entities.Categories;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.StoretSettings.Settings;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;


namespace MarketPlace.Infrastructure.Services.EntityServices.StoretSettings.Settings
{
    public class StoreWritingSettingService : BaseService<StoreWritingSetting, StoreWritingSettingRequestDto, StoreWritingSettingResponseDto>, IStoreWritingSettingService
    {
        private readonly IValidator<StoreWritingSettingRequestDto> _storeWritingSettingValidator;
        public StoreWritingSettingService(IBaseRepository<StoreWritingSetting> repository,
            IValidator<StoreWritingSettingRequestDto> storeWritingSettingValidator) : base(repository)
        {
            _storeWritingSettingValidator = storeWritingSettingValidator;
        }

        public async Task<SingleResponse<StoreWritingSetting>> CreateStoreWritingSetting(StoreWritingSettingRequestDto input, CancellationToken cancellationToken)
        {
            var storeWritingSettingValidation = _storeWritingSettingValidator.Validate(input).GetAllErrorsString();
            if (storeWritingSettingValidation.HasValue()) return (ResponseStatus.ValidationFailed, storeWritingSettingValidation);

            var isStoreExist = await GetAllAsNoTracking<Store>().Where(x => x.Id == input.StoreId).AnyAsync(cancellationToken);
            if (!isStoreExist) return ResponseStatus.NotFound;

            var isCategoryOfPostExist = await GetAllAsNoTracking<PostCategory>().Where(x => x.Id == input.DefaultPostCategoryId).AnyAsync(cancellationToken);
            if (!isCategoryOfPostExist) return ResponseStatus.NotFound;

            return await CreateStoreWritingSetting(input, cancellationToken);
        }
    }
}
