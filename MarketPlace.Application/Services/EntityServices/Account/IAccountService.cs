using MarketPlace.Dto.Auth;
using MarketPlace.Dto.Account;
using MarketPlace.Dto.Jwt;
using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.Account;

namespace MarketPlace.Application.Services.EntityServices.Account;

public interface IAccountService
{
    Task<SingleResponse<bool>> AddPassword(SignInRequestDto userRequest, CancellationToken cancellationToken);
    Task<SingleResponse<bool>> AddUserToRole(string userName, string role, CancellationToken cancellationToken);
    Task<SingleResponse<bool>> ChangePassword(ChangePasswordRequestDto changePasswordRequest);
    Task<SingleResponse<AccessToken>> ConfirmEmail(string email, string code);
    Task<SingleResponse<AccessToken>> ConfirmPhoneNumber(string phoneNumber, string code);
    Task<SingleResponse<bool>> GenerateToken(string userName);
    Task<SingleResponse<AccessToken>> SignIn(SignInRequestDto signInRequest);
    Task<SingleResponse<AccessToken>> SignInUsingOtp(SignInRequestDto signInRequest);
    Task<SingleResponse<User>> SignUp(UserRequestDto userInput, CancellationToken cancellationToken);
}
