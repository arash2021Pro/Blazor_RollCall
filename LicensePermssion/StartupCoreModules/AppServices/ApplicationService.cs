using CoreApplication.ClientApplication;
using CoreApplication.LicenseApplication;
using CoreApplication.OtpApplication;
using CoreApplication.UserApplication;
using CoreBussiness.BussinessEntity.Clients;
using CoreBussiness.BussinessEntity.Licenses;
using CoreBussiness.BussinessEntity.OTP;
using CoreBussiness.BussinessEntity.Users;
using CoreBussiness.IUnitOfWork;
using CoreBussiness.ManagerServices;
using CoreStorage.StorageContext;
using LicensePermssion.StartupCoreModules.CodeGeneratorServices;
using LicensePermssion.StartupCoreModules.CoreAuthenticationService;
using LicensePermssion.StartupCoreModules.DataSeed;
using MapsterMapper;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

namespace LicensePermssion.StartupCoreModules.AppServices;

public static class ApplicationService
{
  public static void RunAppServices(this IServiceCollection service)
  {
    service.AddScoped<IUnitOfWork, ApplicationContext>();
    service.AddScoped<IMapper, Mapper>();
    service.AddScoped<IDatabaseInitializer, DatabaseInitializerService>();
    service.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
    service.AddScoped<IManagerService, ManagerService>();
    service.AddScoped<IUserService, UserService>();
    service.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
    service.AddScoped<ILicenseService, LicenseService>();
    service.AddScoped<ICodeGeneratorService, CodeGeneratorService>();
    service.AddScoped<IClientService, ClientService>();
    service.AddScoped<IOtpService, OtpService>();
  }
}