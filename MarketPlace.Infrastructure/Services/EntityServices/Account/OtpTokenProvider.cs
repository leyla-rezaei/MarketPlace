using OtpNet;
using System.Text;

namespace MarketPlace.Infrastructure.Services.EntityServices.Account;

public class OtpTokenProvider
{
    public string Generate(string userName)
    {
        var totp = CreateTotp(userName);
        var token = totp.ComputeTotp();
        return token;
    }

    //TODO the commented parts should read from appsettings
    private Totp CreateTotp(string userName)
    {
        var secretKey = Encoding.ASCII.GetBytes($"{userName}");//{_appSettings.OtpSettings.SecretKey}");
        var base32Bytes = Base32Encoding.ToBytes(Base32Encoding.ToString(secretKey));

        //TODO the time must read from appsetting
        var totp = new Totp(base32Bytes, step: (int)TimeSpan.Parse("00:02:00").TotalSeconds,
            totpSize: 4);// _appSettings.OtpSettings.TokenSize);

        return totp;
    }

    public bool Validate(string userName, string? token)
    {
        var totp = CreateTotp(userName);
        var window = new VerificationWindow(previous: 1, future: 1);
        var result = totp.VerifyTotp(token, out var timeStepMatched, window);
        return result;
    }
}
