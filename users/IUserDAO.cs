using users.Models;

namespace users
{
    public interface IUserDAO
    {
        bool InsertUser(User user);
        bool UpdateUser(string email, string firstname, string lastname);
        bool DeleteUser(string email);
        User? GetUser(string email);
    }
}
