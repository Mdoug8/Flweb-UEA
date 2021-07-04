using Flweb.Business.Interface;
using Flweb.Data.Converter.Implementation;
using Flweb.Data.VO;
using Flweb.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flweb.Business.Implementation
{
    public class UserBusinessImplementation : IUserBusiness
    {
        private readonly IUserRepository _repository;
        private readonly UserRegisterConverter _converter;

        public UserBusinessImplementation(IUserRepository repository)
        {
            _repository = repository;
            _converter = new UserRegisterConverter();
        }

        public List<UserRegisterVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public UserRegisterVO FindById(long id)
        {
           return _converter.Parse(_repository.FindById(id));
        }

        public async Task<UserRegisterVO> NewUser(UserRegisterVO user)
        {
            var userEntity = _converter.Parse(user);

            await _repository.NewUser(userEntity);

            return _converter.Parse(userEntity);
        }

        public async Task<UserRegisterVO> Update(UserRegisterVO user)
        {
            var userEntity = _converter.Parse(user);

            await _repository.Update(userEntity);

            return _converter.Parse(userEntity);
        }

        public void Delete(long id)
        {
             _repository.Delete(id);
        }
    }
}
