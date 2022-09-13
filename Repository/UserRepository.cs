using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using UserApi.Context;
using UserApi.Model;

namespace UserApi.Repository
{
    public class UserRepository:IUserRepository
    {
        User user = new User();
        readonly UserDbContext userDbContext;

        public UserRepository(UserDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        public User Login(LoginDto loginDto)
        {
            user = GetUserByEmail(loginDto.Email);
            if(user == null)
            {
                return null ;
            }
            else
            {
                return user;
            }
        }

        public async Task<ActionResult<User>> Register(RegisterDto registerDto)
        {
            if (GetUserByEmail(registerDto.Email)==null)
            {
                CreatePasswordHash(registerDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

                user.Address = registerDto.Address;
                user.Name = registerDto.Name;
                user.Email = registerDto.Email;
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.ContactNo = registerDto.ContactNo;
                user.Role = "user";
                userDbContext.Users.Add(user);
                userDbContext.SaveChanges();

                return user;
            }
            return null;
            
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public User GetUserByEmail(string email)
        {
            return userDbContext.Users.FirstOrDefault(x => x.Email == email);
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        
        

    }
}
