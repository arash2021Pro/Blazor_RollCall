namespace LicensePermssion.StartupCoreModules.CodeGeneratorServices;

public class CodeGeneratorService:ICodeGeneratorService
{
    public string GenerateLicense()
    {
        return Guid.NewGuid().ToString().Replace("-", "").Substring(1, 8).ToUpper();
    }
    public string GenerateOtp(int charLen)
    {
        var code = "";
        var rand = new Random();
        for (int i = 1; i <= charLen; i++)
        {
            code += rand.Next(1, 10);
        }
        return code;
    }
}