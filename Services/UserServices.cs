using Microsoft.AspNetCore.Mvc;
using UserApi.Exception;
using UserApi.Model;
using UserApi.Repository;

namespace UserApi.Services
{
    public class UserServices:IUserServices
    {
        readonly IUserRepository _userRepository;
        readonly ITokenServices _tokenServices;
        public UserServices(IUserRepository userRepository,ITokenServices tokenServices)
        {
            _userRepository = userRepository;
            _tokenServices = tokenServices;
        }

        public string Login(LoginDto loginDto)
        {
           
                User user = _userRepository.Login(loginDto);
                if (user == null)
                {
                    return null;
                }
                if (!_userRepository.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt))
                {
                return null;
                //throw new InValidLogin("Invalid Login Credentials");
                }
                return _tokenServices.CreateToken(user);
            
          
        }

        public async Task<ActionResult<User>> Register(RegisterDto registerDto)
        {
            if (registerDto != null)
            {
                 var result =  await _userRepository.Register(registerDto);
                if (result == null)
                {
                    return null;
                }
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
