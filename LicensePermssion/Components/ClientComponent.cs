using CoreBussiness.BussinessEntity.OTP;
using CoreBussiness.IUnitOfWork;
using CoreBussiness.ManagerServices;
using LicensePermssion.Models;
using LicensePermssion.StartupCoreModules.CodeGeneratorServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace LicensePermssion.Components;

public class ClientComponent:ComponentBase
{
    [Inject] private IManagerService ManagerService { get; set; }
    [Inject] private IUnitOfWork Work { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private ICodeGeneratorService CodeGeneratorService { get; set; }
    public string Message { get; set; }

    public async Task ValidateClientAsync(ValidateClientModel clientModel)
    {
        var isCompleted = true;
        var license = await ManagerService.LicenseService.GetLicenseAsync(clientModel.AppSerial);
        if (license == null)
        {
            isCompleted = false;
            Message = "License not found";
        }
        if (isCompleted)
        {
            if (license!.CompanyAddress == null && license.CompanyName == null && license.ConstPhone == null &&
                license.LastName == null && license.Name == null && license.LegalCode == null &&
                license.PhoneNumber == null)
            {
                NavigationManager.NavigateTo("/CompleteLicense");
            }
            var otp = new Otp() {Code = CodeGeneratorService.GenerateOtp(5), LicenseId = license.Id};
            await ManagerService.OtpService.AddOtpAsync(otp);
            var saveChanges = await Work.SaveChangesAsync();
            if (saveChanges > 0)
            {
                //MessageService
                NavigationManager.NavigateTo($"/ValidatePhone?PhoneNumber={license.PhoneNumber}");
            }
        }
        
    }
}