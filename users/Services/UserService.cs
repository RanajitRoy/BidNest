using items.Data;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using users.Models;

namespace users.Services
{
    public class UserService : IUserService
    {
        IConfiguration _config;
        AppDbContext _context;
        public UserService(IConfiguration config, AppDbContext context)
        {
            _config = config;
            _context = context;
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
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User? GetUser(string email)
        {
            User? user = _context.Users.First(x => x.Email == email);
            return user;
        }

        public void UpdateUser(string email, string firstName, string lastName)
        {
            User? user =_context.Users.Where(x => x.Email == email).FirstOrDefault();
            if(user == null) { return; }
            user.FirstName = firstName;
            user.LastName = lastName;
            _context.SaveChanges();
        }

        public void DeleteUser(string email)
        {
            _context.Users.Where(x => x.Email == email).ExecuteDelete();
            _context.SaveChanges();
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
