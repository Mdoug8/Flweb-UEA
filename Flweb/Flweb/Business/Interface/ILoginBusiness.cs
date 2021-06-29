using Flweb.Data.VO;

namespace Flweb.Business.Interface
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);

        TokenVO ValidateCredentials(TokenVO token);

        bool RevokeToken(string userName);
    }
}
