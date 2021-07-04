using Flweb.Data.VO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flweb.Business.Interface
{
    public interface IUserBusiness
    {
        List<UserRegisterVO> FindAll();
        UserRegisterVO FindById(long id);
        Task<UserRegisterVO> NewUser(UserRegisterVO user);
        Task<UserRegisterVO> Update(UserRegisterVO user);
        void Delete(long id);
    }
}
