using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using UserApi.Exception;
using UserApi.Model;
using UserApi.Services;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionHandler]
    public class UserController : ControllerBase
    {
        readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<User>> Register(RegisterDto registerDto)
        {
            var result = await _userServices.Register(registerDto);
            if (result == null)
            {
                //Ok("User Already Exist");
                return null;
            }
            
            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginDto loginDto)
        {
            var result = _userServices.Login(loginDto);
            //if (result == null)
            //{
            //    return 
            //}
            return Ok(result);
        }
    }
}
