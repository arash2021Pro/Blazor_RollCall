using CoreBussiness.BussinessEntity.Licenses;
using CoreBussiness.IUnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CoreApplication.LicenseApplication;

public class LicenseService:ILicenseService
{
    private DbSet<License> _licenses;
    public LicenseService(IUnitOfWork work)
    {
        _licenses = work.Set<License>();
    }

    public async Task AddLicenseAsync(License license) => await _licenses.AddAsync(license);

    public async Task<License?> GetLicenseAsync(string? licenseSerial) =>
        await _licenses.AsTracking().FirstOrDefaultAsync(x => x.LicenseCode == licenseSerial);

    public async Task<License?> GetLicenseAsync(int licenseId) =>
        await _licenses.AsTracking().FirstOrDefaultAsync(x => x.Id == licenseId);
}