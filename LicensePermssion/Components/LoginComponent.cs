using System.Security.Cryptography;
using System.Text;
using CoreBussiness.ManagerServices;
using LicensePermssion.Models;
using LicensePermssion.StartupCoreModules.CoreAuthenticationService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace LicensePermssion.Components;

public class LoginComponent:ComponentBase
{
    [Inject] private IManagerService ManagerService { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private AuthenticationStateProvider _authenticationStateProvider { get; set; }
    public async Task LoginAsync(LoginModel loginModel)
    {
        var isCompleted = true;
        var user = await ManagerService.UserService.GetUserAsync(loginModel.UserName,loginModel.Password);
        if (user == null)
        {
            isCompleted = false;
        }
        if (isCompleted)
        {
            var CustomAuthProvider = (CustomAuthProvider)  _authenticationStateProvider;
            await CustomAuthProvider.UpdateAuthenticationStateAsync(new UserSession()
                {Id = user.Id, Role = "admin",UserName = user.UserName});
            NavigationManager.NavigateTo("/",true);   
        }
    }
  
}