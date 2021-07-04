using Flweb.Data.VO;
using Flweb.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flweb.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User> NewUser(User user);

        List<User> FindAll();
        User FindById(long id);
        Task<User> Update(User user);
        void Delete(long id);

        User ValidateUser(UserRegisterVO user);
        User ValidateCredentials(UserLoginVO user);

        User ValidateCredentials(string username);

        Task<bool> RevokeToken(string username);

        Task<User> RefreshUserInfo(User user);
    }
}
