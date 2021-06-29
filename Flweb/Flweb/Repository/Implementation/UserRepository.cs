using Flweb.Data.VO;
using Flweb.Model;
using Flweb.Model.Context;
using Flweb.Repository.Interface;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Flweb.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context)
        {
            _context = context;
        }

        public User ValidateCredentials(UserVO user)
        {
            // encrypta a senha e manda para a variavel pass
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());

            //caso o usuario exista no banco de dados ele retorna o usuario
            return _context.Users.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass));
        }

        public User ValidateCredentials(string userName)
        {
            // verifica se existe um usuario com esse username e caso exista retorna ele
            return _context.Users.SingleOrDefault(u => (u.UserName == userName));
        }

        public bool RevokeToken(string userName)
        {
            //verifica se o usuario existe e caso exista salvar ele em user
            var user = _context.Users.SingleOrDefault(u => (u.UserName == userName));
            //verfica se o usuario e nulo e caso seja nulo ele retorna um false
            if (user is null) return false;
            //atualizar o valor do refreshToken do usuario
            user.RefreshToken = null;
            //atualiza as informacoes no banco de dados
            _context.SaveChanges();
            return true;
        }

        //atualizar dados na tabela usuario
        public User RefreshUserInfo(User user)
        {
            if (!_context.Users.Any(u => u.Id.Equals(user.Id))) return null;

            // se o id do usuario existir na tabela então ele pegar o usuario e manda pra result
            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));
            if (result != null)
            {
                try
                {
                    //ele seta os valores do usuario
                    _context.Entry(result).CurrentValues.SetValues(user);
                    // salva os valores do usuario
                    _context.SaveChanges();

                    //retorna o usuario com os valores atualizados
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

    }
}
