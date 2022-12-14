using CoreBussiness.BussinessEntity.OTP;
using CoreBussiness.IUnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CoreApplication.OtpApplication;

public class OtpService:IOtpService
{
    private DbSet<Otp> _otps;
    public OtpService(IUnitOfWork work)
    {
        _otps = work.Set<Otp>();
    }

    public async Task AddOtpAsync(Otp otp) => await _otps.AddAsync(otp);

    public async Task<Otp?> GetOtpAsync(string? code) =>
        await _otps.AsTracking().FirstOrDefaultAsync(x => x.Code == code);

}