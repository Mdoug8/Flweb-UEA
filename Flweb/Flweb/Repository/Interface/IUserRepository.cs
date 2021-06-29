using Flweb.Data.VO;
using Flweb.Model;

namespace Flweb.Repository.Interface
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);

        User ValidateCredentials(string username);

        bool RevokeToken(string username);

        User RefreshUserInfo(User user);
    }
}
