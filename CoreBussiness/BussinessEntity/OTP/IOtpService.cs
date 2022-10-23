namespace CoreBussiness.BussinessEntity.OTP;

public interface IOtpService
{
   Task AddOtpAsync(Otp otp);
   Task<Otp?> GetOtpAsync(string? code);
}