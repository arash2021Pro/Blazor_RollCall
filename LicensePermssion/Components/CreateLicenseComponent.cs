using CoreBussiness.BussinessEntity.Clients;
using CoreBussiness.BussinessEntity.Licenses;
using CoreBussiness.IUnitOfWork;
using CoreBussiness.ManagerServices;
using LicensePermssion.Models;
using LicensePermssion.StartupCoreModules.CodeGeneratorServices;
using Microsoft.AspNetCore.Components;

namespace LicensePermssion.Components;

public class CreateLicenseComponent:ComponentBase
{
    [Inject] public IManagerService ManagerService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public IUnitOfWork Work { get; set; }
    [Inject] public ICodeGeneratorService CodeGeneratorService { get; set; }

    public async Task RegisterLicenseAsync(CreateLicenseModel licenseModel)
    {
        for (int i = 1; i <= licenseModel.AppSerialCount ; i++)
        {
            var license = new License();
            license.IsActive = true;
            license.IsSmsPanelActive = licenseModel.IsSmsPanelActive;
            license.IsMobileVersionActive = licenseModel.IsMobileVersionActive;
            license.AppSerialCount = licenseModel.AppSerialCount;
            license.ClientCount = licenseModel.ClientCount;
            license.LicenseCode = CodeGeneratorService.GenerateLicense();
            license.SoftwareType = licenseModel.GetSoftwareType(licenseModel.LicenseType);
            await ManagerService.LicenseService.AddLicenseAsync(license);
            for (int j = 1; j <= licenseModel.ClientCount; j++)
            {
                var client = new Client();
                client.License = license;
                client.LicenseSerial = license.LicenseCode;
                await ManagerService.ClientService.AddClientAsync(client);
            }
        } 
        await Work.SaveChangesAsync();
    }
}