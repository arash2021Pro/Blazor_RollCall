using CoreBussiness.BaseEntity;

namespace CoreBussiness.BussinessEntity.Users;

public class User:Core
{
    public string?UserName { get; set; }
    public string?Password { get; set; }
    public bool IsAdmin { get; set; } = false;
}