using CoreBussiness.IUnitOfWork;
using CoreBussiness.ManagerServices;
using LicensePermssion.LicenseServices;
using LicensePermssion.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LicensePermssion.Components;

public class ValidatePhoneComponent:ComponentBase
{
    [Inject] private IManagerService ManagerService { get; set; }
    [Inject] private IUnitOfWork Work { get; set; }
    [Inject] private IJSRuntime _jsRuntime { get; set; }
    [Parameter]
    [SupplyParameterFromQuery]
    public string PhoneNumber { get; set; }
    public string Message { get; set; }
    public async Task ValidatePhoneAsync(VerificationModel model)
    {
        var isCompleted = true;
        var otp = await ManagerService.OtpService.GetOtpAsync(model.Code);
        if (otp == null)
        {
            isCompleted = false;
            Message = "No such infos found";
        }
        if (isCompleted)
        {
            var license = await ManagerService.LicenseService.GetLicenseAsync(otp.LicenseId);
            var client = await ManagerService.ClientService.GetClientAsync(license.Id);
            if (otp.IsAuthentic)
            {
                otp.IsUsed = true;
                license.IsOtpConfirmed = true;
                var saveChanges = await Work.SaveChangesAsync();
                if (saveChanges > 0)
                {
                    var Content = LicenseConvertor.ConvertLicense(license,client);
                    await _jsRuntime.InvokeVoidAsync("BlazorDownloadFile", Content,"application/xml","License.Key.xml");
                }
                else
                {
                    Message = "something went wrong";
                }
            }
            else
            {
                Message = "code is not valid";
            }
        }
    }
}