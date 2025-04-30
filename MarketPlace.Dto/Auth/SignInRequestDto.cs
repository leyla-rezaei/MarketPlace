namespace MarketPlace.Dto.Auth;
public class SignInRequestDto
{
    public string? UserName { get; set; }
    public string?  Password { get; set; }
    public string? OtpToken { get; set; }
}
