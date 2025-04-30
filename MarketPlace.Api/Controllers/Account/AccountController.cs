using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Account;
using MarketPlace.Domain.Entities.Account;
using MarketPlace.Dto.Account;
using MarketPlace.Dto.Auth;
using MarketPlace.Dto.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService accountService)
        {
            _service = accountService;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<User>> SignUp(UserRequestDto signUpRequest, CancellationToken cancellationToken)
        {
            return await _service.SignUp(signUpRequest, cancellationToken);
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<AccessToken>> SignInUsingOtp(SignInRequestDto signInRequest)
        {
            return await _service.SignInUsingOtp(signInRequest);
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<AccessToken>> SignIn(SignInRequestDto signInRequest)
        {
            return await _service.SignIn(signInRequest);
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<SingleResponse<bool>> ChangePassword(ChangePasswordRequestDto changePasswordRequest)
        {
            return await _service.ChangePassword(changePasswordRequest);
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<bool>> AddPassword(SignInRequestDto userRequest, CancellationToken cancellationToken)
        {
            return await _service.AddPassword(userRequest, cancellationToken);
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<SingleResponse<bool>> AddUserToRole(string userName, string role, CancellationToken cancellationToken)
        {
            return await _service.AddUserToRole(userName, role, cancellationToken);
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<bool>> SendOtpTokenToken(string userName)
        {
            return await _service.GenerateToken(userName);
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<AccessToken>> ConfirmPhoneNumber(string phoneNumber, string code)
        {
            return await _service.ConfirmPhoneNumber(phoneNumber, code);
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<AccessToken>> ConfirmEmail(string email, string code)
        {
            return await _service.ConfirmEmail(email, code);
        }
    }
}
