using Flweb.Data.VO;
using Flweb.Model;

namespace Flweb.Repository.Interface
{
    public interface IUserRepository
    {
        User NewUser(User user);

        User ValidateUser(UserRegisterVO user);
        User ValidateCredentials(UserLoginVO user);

        User ValidateCredentials(string username);

        bool RevokeToken(string username);

        User RefreshUserInfo(User user);
    }
}
