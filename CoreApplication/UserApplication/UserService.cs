using System.Security.Cryptography;
using System.Text;
using CoreBussiness.BussinessEntity.Users;
using CoreBussiness.IUnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CoreApplication.UserApplication;

public class UserService:IUserService
{
    private DbSet<User> _users;
    public UserService(IUnitOfWork work)
    {
        _users = work.Set<User>();
    }

    public async Task AddUserAsync(User user) => await _users.AddAsync(user);

    public async Task<bool> IsUserExistsAsync(string username, string password) =>
        await _users.AnyAsync(x => x.UserName == username && x.Password == password);

    public async Task<User?> GetUserAsync(int userId) => await _users.FirstOrDefaultAsync(x => x.Id == userId);

    public async Task<User?> GetUserAsync(string? username, string? password) =>
        await _users.FirstOrDefaultAsync(x => x.UserName == username && x.Password.Equals(GenerateHashedPassword(password)));
    private string GenerateHashedPassword(string? password)
    {
        if (String.IsNullOrEmpty(password))
            return "";
        using var sha = new SHA512Managed();
        var bytes = Encoding.ASCII.GetBytes(password);
        var encripted = sha.ComputeHash(bytes);
        return Encoding.ASCII.GetString(encripted);
    }

}