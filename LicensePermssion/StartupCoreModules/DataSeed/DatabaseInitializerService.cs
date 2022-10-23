using System.Security.Cryptography;
using System.Text;
using CoreBussiness.BussinessEntity.Users;
using CoreStorage.StorageContext;

namespace LicensePermssion.StartupCoreModules.DataSeed;

public class DatabaseInitializerService:IDatabaseInitializer
{
    private ApplicationContext _applicationContext;
    public DatabaseInitializerService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    public void SeedData()
    {
        if (!_applicationContext.Users.Any())
        {
            var user = new User();
            user.UserName = "arash";
            user.Password = GenerateHashedPassword("admin");
            user.IsAdmin = true;
            _applicationContext.Users.Add(user);
            _applicationContext.SaveChanges();
        }

    }
    private string GenerateHashedPassword(string? password)
    {
        if (String.IsNullOrEmpty(password))
            return "";
        using var sha = new SHA512Managed();
        var bytes = Encoding.ASCII.GetBytes(password);
        var encripted = sha.ComputeHash(bytes);
        return Encoding.ASCII.GetString(encripted);
    }
}