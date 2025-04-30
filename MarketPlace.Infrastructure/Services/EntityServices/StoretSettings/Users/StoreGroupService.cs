using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Users;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.StoretSettings.Users;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;


namespace MarketPlace.Infrastructure.Services.EntityServices.StoretSettings.Users
{
    public class StoreGroupService : BaseService<StoreGroup, StoreGroupRequestDto, StoreGroupResponseDto>, IStoreGroupService
    {
        private readonly IValidator<StoreGroupRequestDto> _storeGroupValidator;

        public StoreGroupService(IBaseRepository<StoreGroup> repository,
            IValidator<StoreGroupRequestDto> storeGroupValidator) : base(repository)
        {
            _storeGroupValidator = storeGroupValidator;
        }

        public  async Task<SingleResponse<StoreGroup>> CreateStoreGroup(StoreGroupRequestDto input, CancellationToken cancellationToken)
        {
            var storeGroupValidation = _storeGroupValidator.Validate(input).GetAllErrorsString();
            if (storeGroupValidation.HasValue()) return (ResponseStatus.ValidationFailed, storeGroupValidation);

            var isStoreExist = await GetAllAsNoTracking<Store>().Where(x => x.Id == input.StoreId).AnyAsync(cancellationToken);
            if (!isStoreExist) return ResponseStatus.NotFound;

            return await CreateStoreGroup(input, cancellationToken);
        }
    }
}