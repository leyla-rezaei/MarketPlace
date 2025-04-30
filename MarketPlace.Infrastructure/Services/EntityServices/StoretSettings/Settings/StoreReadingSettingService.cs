using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings.Settings;
using MarketPlace.Domain.Entities.Posts;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.StoretSettings.Settings;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.StoretSettings.Settings
{
    public class StoreReadingSettingService : BaseService<StoreReadingSetting, StoreReadingSettingRequestDto, StoreReadingSettingResponseDto>, IStoreReadingSettingService
    {
        private readonly IValidator<StoreReadingSettingRequestDto> _storeReadingSettingValidator;
        public StoreReadingSettingService(IBaseRepository<StoreReadingSetting> repository,
            IValidator<StoreReadingSettingRequestDto> storeReadingSettingValidator) : base(repository)
        {
            _storeReadingSettingValidator = storeReadingSettingValidator;
        }

        public async Task<SingleResponse<StoreReadingSetting>> CreateStoreReadingSetting(StoreReadingSettingRequestDto input, CancellationToken cancellationToken)
        {
            var storeReadingSettingValidation = _storeReadingSettingValidator.Validate(input).GetAllErrorsString();
            if (storeReadingSettingValidation.HasValue()) return (ResponseStatus.ValidationFailed, storeReadingSettingValidation);

            var isStoreExist = await GetAllAsNoTracking<Store>().Where(x => x.Id == input.StoreId).AnyAsync(cancellationToken);
            if (!isStoreExist) return ResponseStatus.NotFound;

            var isPostExist = await GetAllAsNoTracking<Post>().Where(x => x.Id == input.HomePageId).AnyAsync(cancellationToken);
            if (!isPostExist) return ResponseStatus.NotFound;

            var isPostsPageExist = await GetAllAsNoTracking<Post>().Where(x => x.Id == input.PostsPageId).AnyAsync(cancellationToken);
            if (!isPostsPageExist) return ResponseStatus.NotFound;

            return await CreateStoreReadingSetting(input, cancellationToken);
        }
    }
}
