using UserApi.Model;

namespace UserApi.Services
{
    public interface ITokenServices
    {
        string CreateToken(User user);
    }
}
