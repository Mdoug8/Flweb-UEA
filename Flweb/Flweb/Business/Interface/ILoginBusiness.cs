using Flweb.Data.VO;
using System.Threading.Tasks;

namespace Flweb.Business.Interface
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserLoginVO user);

        TokenVO ValidateCredentials(TokenVO token);

        Task<bool> RevokeToken(string userName);
    }
}
