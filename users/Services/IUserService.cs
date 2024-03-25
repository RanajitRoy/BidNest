using users.Models;

namespace users.Services
{
    public interface IUserService
    {
        void CreateUser(User user);
        User? GetUser(string email);
    }
}
