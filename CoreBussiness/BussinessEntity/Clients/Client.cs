using CoreBussiness.BaseEntity;
using CoreBussiness.BussinessEntity.Licenses;

namespace CoreBussiness.BussinessEntity.Clients;

public class Client:Core
{
    public string? LicenseSerial { get; set; }
    public string? SystemSerial { get; set; }
    public int LicenseId { get; set; }
    public License License { get; set; }
}