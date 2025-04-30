namespace MarketPlace.Application;

public class AppSettings
{
    public IdentitySettings IdentitySettings { get; set; }
    public JwtSettings JwtSettings { get; set; }
}

public class IdentitySettings
{
    public bool PasswordRequireDigit { get; set; }
    public int PasswordRequiredLength { get; set; }
    public bool PasswordRequireNonAlphanumeric { get; set; }
    public bool PasswordRequireUppercase { get; set; }
    public bool PasswordRequireLowercase { get; set; }
    public bool RequireUniqueEmail { get; set; }
    public TimeSpan ConfirmationEmailResendDelay { get; set; }
    public TimeSpan ResetPasswordEmailResendDelay { get; set; }
}

public class JwtSettings
{
    public string SecretKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string EncryptKey { get; set; }
    public int ExpirationMinutes { get; set; }
}