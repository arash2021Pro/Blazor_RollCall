namespace LicensePermssion.StartupCoreModules.CodeGeneratorServices;

public interface ICodeGeneratorService
{
    string GenerateLicense();
    string GenerateOtp(int charLen);
}