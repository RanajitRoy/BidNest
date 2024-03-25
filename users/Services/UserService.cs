using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using users.Models;

namespace users.Services
{
    public class UserService : IUserService
    {
        IConfiguration _config;
        IUserDAO _userDAO;
        public UserService(IConfiguration config, IUserDAO dao)
        {
            _config = config;
            _userDAO = dao;
        }

        public void CreateUser(User user)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: user.HashedPassword!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            user.HashedPassword = hashed;
            user.Salt = Convert.ToBase64String(salt);
            _userDAO.InsertUser(user);
        }

        public User? GetUser(string email)
        {
            User? user = _userDAO.GetUser(email);
            return user;
        }

        public void UpdateUser(string email, string firstName, string lastName)
        {
            _userDAO.UpdateUser(email, firstName, lastName);
        }

        public void DeleteUser(string email)
        {
            _userDAO.DeleteUser(email);
        }
        public bool VerifyCredentials(string email, string password)
        {
            User? user = GetUser(email);
            if (user == null)
            {
                return false;
            }
            else
            {
                byte[] salt = Convert.FromBase64String(user.Salt);
                string hashedPass = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password!,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));
                return user.HashedPassword == hashedPass;
            }
        }
    }
}
