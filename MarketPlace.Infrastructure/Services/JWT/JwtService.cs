using MarketPlace.Domain.Entities.Account;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using MarketPlace.Application;
using Microsoft.Extensions.Options;
using MarketPlace.Dto.Jwt;

namespace MarketPlace.Infrastructure.Services.JWT;

public class JwtService : IJwtService
{
    private readonly SignInManager<User> _signInManager;
    private readonly JwtSettings _jwtSettings;
    private readonly IConfiguration _configuration;

    public JwtService(SignInManager<User> signInManager
        , IOptionsSnapshot<AppSettings> appSettings
        , IConfiguration configuration)
    {
        _signInManager = signInManager;
        _jwtSettings = appSettings.Value.JwtSettings;
        _configuration = configuration;
    }

    public async Task<AccessToken> GenerateToken(User user)
    {
        var secretKey = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

        var claims = (await _signInManager.ClaimsFactory.CreateAsync(user)).Claims;

        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            IssuedAt = DateTime.Now,
            Expires = DateTime.Now.AddMinutes(_jwtSettings.ExpirationMinutes),
            SigningCredentials = signingCredentials,
            Subject = new ClaimsIdentity(claims)
        };

        var securityTokenHandler = new JwtSecurityTokenHandler();
        var securityToken = securityTokenHandler.CreateToken(descriptor);
        var token = securityTokenHandler.WriteToken(securityToken);

        return new AccessToken
        {
            Token = token,
            ExpiresIn = (int)TimeSpan.FromHours(2).TotalSeconds
        };
    }
}
