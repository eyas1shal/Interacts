using Task5.Models;
using Task5.Tabels;

namespace Task5.Services.Users
{
    public interface IUserServices
    {
        Task<User> AddUser(UserModel m);
        Task<User?> GetUser(AuthModel m);
        string CreateToken(string userName);
        string GetCurrentLoggedIn();
    }
}
