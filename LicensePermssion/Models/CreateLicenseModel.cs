using CoreBussiness.BussinessEntity.Licenses;

namespace LicensePermssion.Models;

public class CreateLicenseModel
{
    public string? LicenseType { get; set; }
    public bool IsSmsPanelActive { get; set; }
    public bool IsMobileVersionActive { get; set; }
    public int ClientCount { get; set; }
    public int AppSerialCount { get; set; }

    public SoftwareType GetSoftwareType(string? type)
    {
        switch (type)
        {
            case "base":
                return SoftwareType.Base;
            case "advanced":
                return SoftwareType.Advanced;
            case "pro" :
                return SoftwareType.Pro;
        }
        return 0;
    }
}