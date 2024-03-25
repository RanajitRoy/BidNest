using users.Models;

namespace users.Services
{
    public interface IUserService
    {
        void CreateUser(User user);
        User? GetUser(string email);
        void UpdateUser(string email, string firstName, string lastName);
        void DeleteUser(string email);
        bool VerifyCredentials(string email, string password);
    }
}
