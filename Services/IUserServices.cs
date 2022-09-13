using Microsoft.AspNetCore.Mvc;
using UserApi.Model;

namespace UserApi.Services
{
    public interface IUserServices
    {
        string Login(LoginDto loginDto);
        Task<ActionResult<User>> Register(RegisterDto registerDto);
    }
}
