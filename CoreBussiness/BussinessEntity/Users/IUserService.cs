namespace CoreBussiness.BussinessEntity.Users;

public interface IUserService
{
    Task AddUserAsync(User user);
    Task<bool> IsUserExistsAsync(string username, string password);
    Task<User?> GetUserAsync(int userId);
    Task<User?> GetUserAsync(string? username, string? password);
}