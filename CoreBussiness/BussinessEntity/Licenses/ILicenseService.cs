namespace CoreBussiness.BussinessEntity.Licenses;

public interface ILicenseService
{
    Task AddLicenseAsync(License license);
    Task<License?> GetLicenseAsync(string? licenseSerial);
    Task<License?> GetLicenseAsync(int licenseId);
}