using Flweb.Data.VO;

namespace Flweb.Business.Interface
{
    public interface ILoginBusiness
    {
        UserRegisterVO NewUser(UserRegisterVO user);
        TokenVO ValidateCredentials(UserLoginVO user);

        TokenVO ValidateCredentials(TokenVO token);

        bool RevokeToken(string userName);
    }
}
