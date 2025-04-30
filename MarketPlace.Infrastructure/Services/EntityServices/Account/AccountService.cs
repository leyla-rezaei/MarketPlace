using Mapster;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Account;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Enums.Account;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Account;
using MarketPlace.Dto.Auth;
using MarketPlace.Dto.Jwt;
using MarketPlace.Infrastructure.Identity.Models;
using MarketPlace.Infrastructure.Services.EntityServices.Account.Identity;
using MarketPlace.Infrastructure.Services.JWT;
using Microsoft.AspNetCore.Identity;

namespace MarketPlace.Infrastructure.Services.EntityServices.Account;

public class AccountService : IAccountService
{
    private readonly SignInManager<User> _signInManager;
    private readonly CustomeUserManager _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly OtpTokenProvider _otpTokenProvider;
    private readonly IJwtService _jwtService;
    private readonly IBaseService<User, UserRequestDto, UserResponseDto> _service;
    private readonly IBaseRepository<User> _repository;

    public AccountService(SignInManager<User> signInManager,
                            CustomeUserManager userManager,
                            RoleManager<Role> roleManager,
                            OtpTokenProvider otpTokenProvider,
                            IJwtService jwtService,
                            IBaseService<User, UserRequestDto, UserResponseDto> service, IBaseRepository<User> repository)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
        _otpTokenProvider = otpTokenProvider;
        _jwtService = jwtService;
        _service = service;
        _repository = repository;
    }

    public async Task<SingleResponse<AccessToken>> SignIn(SignInRequestDto signInRequest)
    {
        var user = await _userManager.FindByNameAsync(signInRequest.UserName);

        if (user is null)
            return ResponseStatus.UserNameNotFound;

        var checkPasswordResult =
            await _signInManager.CheckPasswordSignInAsync(user, signInRequest.Password, lockoutOnFailure: true);

        if (checkPasswordResult.IsLockedOut)
            return ResponseStatus.UserLockedOut;

        if (checkPasswordResult.Succeeded is false)
            return ResponseStatus.UserNameOrPasswordIsInCorrect;

        return await _jwtService.GenerateToken(user);
    }


    private async Task<SingleResponse<AccessToken>> SignIn(User user)
    {
        if (user is null)
            return ResponseStatus.UserNameNotFound;

        await _signInManager.SignInAsync(user, false);

        return await _jwtService.GenerateToken(user);
    }

    public async Task<SingleResponse<AccessToken>> SignInUsingOtp(SignInRequestDto signInRequest)
    {
        var user = await _userManager.FindByNameAsync(signInRequest.UserName);

        if (user is null)
            return ResponseStatus.UserNameNotFound;

        var result = _otpTokenProvider.Validate(user.UserName, signInRequest.OtpToken);

        if (result is false)
            return ResponseStatus.OtpTokenIsExpiredOrInvaidToken;

        return await SignIn(user);
    }

    public async Task<SingleResponse<bool>> ChangePassword(ChangePasswordRequestDto changePasswordRequest)
    {
        User user = await _userManager.FindByIdAsync(changePasswordRequest.UserId.ToString());

        if (user is null)
            return ResponseStatus.UserNameNotFound;

        IdentityResult result =
            await _userManager.ChangePasswordAsync(user, changePasswordRequest.CurrentPassword, changePasswordRequest.NewPassword);

        if (result.Succeeded is false)
            return string.Join(", ", result.Errors.Select(e => e.Description));

        return true;
    }

    public async Task<SingleResponse<bool>> AddPassword(SignInRequestDto userRequest, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(userRequest.UserName);

        if (user is null)
            return ResponseStatus.UserNameNotFound;

        var result = await _userManager.AddPasswordAsync(user, userRequest.Password);

        if (!result.Succeeded)
            return string.Join(", ", result.Errors.Select(e => e.Description));

        return true;
    }

    public async Task<SingleResponse<User>> SignUp(UserRequestDto userInput, CancellationToken cancellationToken)
    {
        string userName;
        if (userInput.UserNature == UserNature.PhoneNumber)
            userName = userInput.PhoneNumber;
        else
            userName = userInput.Email;

        var existingUser = await _userManager.FindByNameAsync(userName);
        if (existingUser is not null) return ResponseStatus.UserAlreadyRegistered;

        var userToAdd = userInput.Adapt<User>();
        userToAdd.UserName = userName;

        var result = await _userManager.CreateAsync(userToAdd, userInput.Password);

        if (!result.Succeeded)
            return string.Join(", ", result.Errors.Select(e => e.Description));


        #region user Roles
        //Add user to input role and it also adds the user as a subscriber
        string subscriberRole = Enum.GetName(typeof(RoleType), RoleType.Subscriber);
        await AddUserToRole(userName, subscriberRole, cancellationToken);

        if (userInput.RoleType != RoleType.Subscriber)
        {
            var userRole = Enum.GetName(typeof(RoleType), userInput.RoleType);
            await AddUserToRole(userName, subscriberRole, cancellationToken);
        }
        #endregion

        await GenerateToken(userName);

        return userToAdd;
    }

    public async Task<SingleResponse<bool>> AddUserToRole(string userName, string role, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(userName);

        if (user is null)
            return ResponseStatus.UserNameNotFound;

        var isRoleExist = await _roleManager.RoleExistsAsync(role);
        if (!isRoleExist)
            await _roleManager.CreateAsync(new() { Name = role });

        //TODO find why this line cuse error
        // await _userManager.AddToRoleAsync(user, role);

        return true;
    }

    public async Task<SingleResponse<bool>> GenerateToken(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);

        if (user is null)
            return ResponseStatus.UserNameNotFound;

        var token = _otpTokenProvider.Generate(userName);
        //var message = $"Your verification code is: {phoneCode}. It will expire at {expirationTime}."
        //_accountNotificationService.SendOtpToken(false, userToAdd, token);

        return true;
    }

    public async Task<SingleResponse<AccessToken>> ConfirmPhoneNumber(string phoneNumber, string code)
    {
        var user = await _userManager.FindByNameAsync(phoneNumber);
        if (user is null)
            return ResponseStatus.UserNameNotFound;

        bool phoneNumberConfirmed = _otpTokenProvider.Validate(user.UserName, code);

        if (!phoneNumberConfirmed)
            return ResponseStatus.OtpTokenIsExpiredOrInvaidToken;

        string token = await _userManager.GenerateChangePhoneNumberTokenAsync(user, user.PhoneNumber);
        await _userManager.VerifyChangePhoneNumberTokenAsync(user, token, user.PhoneNumber);


        var result = await _userManager.ChangePhoneNumberAsync(user, user.PhoneNumber, token);
        if (!result.Succeeded)
            return (ResponseStatus.SettingPhoneConfimationToTrueFailed, string.Join(", ", result.Errors.Select(e => e.Description)));

        return await SignIn(user);
    }

    public async Task<SingleResponse<AccessToken>> ConfirmEmail(string email, string code)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
            return ResponseStatus.UserNameNotFound;

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var result = await _userManager.ConfirmEmailAsync(user, token);

        if (!result.Succeeded)
            return (ResponseStatus.SettingPhoneConfimationToTrueFailed, string.Join(", ", result.Errors.Select(e => e.Description)));

        return await SignIn(user);
    }
}
