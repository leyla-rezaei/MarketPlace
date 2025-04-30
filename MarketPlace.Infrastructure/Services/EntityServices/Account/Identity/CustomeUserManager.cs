using MarketPlace.Domain.Entities.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MarketPlace.Infrastructure.Services.EntityServices.Account.Identity;

public class CustomeUserManager : UserManager<User>
{
    public CustomeUserManager(IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators,
        IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<User>> logger)
        : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    { }

    public override Task<IdentityResult> CreateAsync(User user)
    {
        var nowUtc = DateTimeOffset.UtcNow;

        user.CreationDate = nowUtc;
        return base.CreateAsync(user);
    }

    public override Task<IdentityResult> UpdateAsync(User user)
    {
        var nowUtc = DateTimeOffset.UtcNow;

        user.ModificationDate = nowUtc;

        return base.UpdateAsync(user);
    }
}
