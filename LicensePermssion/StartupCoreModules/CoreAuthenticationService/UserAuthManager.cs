using System.Security.Claims;

namespace LicensePermssion.StartupCoreModules.CoreAuthenticationService;

public static class UserAuthManager
{
    public static int GetCurrentUserId(this ClaimsPrincipal claimsPrincipal)
    {
        
        var userId = 0;
        try
        {
            userId = int.Parse(claimsPrincipal.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
        }
        catch (Exception e)
        {
            
        }
        return userId;
        
    }
}