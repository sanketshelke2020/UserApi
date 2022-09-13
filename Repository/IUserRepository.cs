using Microsoft.AspNetCore.Mvc;
using UserApi.Model;

namespace UserApi.Repository
{
    public interface IUserRepository
    {
        User Login(LoginDto loginDto);
        Task<ActionResult<User>> Register(RegisterDto registerDto);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
