using Flweb.Data.Converter.Contract;
using Flweb.Data.VO;
using Flweb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flweb.Data.Converter.Implementation
{
    public class UserRegisterConverter : IParser<UserRegisterVO, User>, IParser<User, UserRegisterVO>
    {
        public User Parse(UserRegisterVO origin)
        {
            if (origin == null) return null;

            return new User
            {
                UserName = origin.UserName,
                Name = origin.Name,
                Password = origin.Password
            };
        }

        public UserRegisterVO Parse(User origin)
        {
            if (origin == null) return null;

            return new UserRegisterVO
            {
                UserName = origin.UserName,
                Name = origin.Name,
                Password = origin.Password
            };
        }

        public List<User> Parse(List<UserRegisterVO> origin)
        {
            if (origin == null)
            {
                return null;
            }
            else
            {
                return origin.Select(item => Parse(item)).ToList();
            }
        }

        public List<UserRegisterVO> Parse(List<User> origin)
        {
            if (origin == null)
            {
                return null;
            }
            else
            {
                return origin.Select(item => Parse(item)).ToList();
            }
        }
    }
}
