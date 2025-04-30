using MarketPlace.Domain.Entities.Account;
using MarketPlace.Dto.Jwt;

namespace MarketPlace.Infrastructure.Services.JWT;

public interface IJwtService
{
    Task<AccessToken> GenerateToken(User user);
}