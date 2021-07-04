using Flweb.Data.VO;
using Flweb.Model;
using Flweb.Model.Context;
using Flweb.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Flweb.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        protected readonly MySQLContext _context;

        private DbSet<User> dataset;

        public UserRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<User>();
        }
        public List<User> FindAll()
        {
           return _context.Users.ToList();
        }

        public User FindById(long id)
        {
            return _context.Users.SingleOrDefault(p => p.Id.Equals(id));
        }

        public async Task<User> NewUser(User user)
        {
            // encrypta a senha e manda para a variavel pass
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            try
            {
                user.Status = 1;
                user.Password = pass;
                await dataset.AddAsync(user);
                await _context.SaveChangesAsync();

                return user;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> Update(User user)
        {
            if(!Exists(user.Id)) return null;
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());

            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));

            if(result != null)
            {
                try
                {
                    user.Password = pass;
                    _context.Entry(result).CurrentValues.SetValues(user);
                    //dataset.Update(user);
                    await _context.SaveChangesAsync();
                    return result;

                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public async void Delete(long id)
        {
            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                dataset.Remove(result);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        
        public User ValidateCredentials(UserLoginVO user)
        {
            // encrypta a senha e manda para a variavel pass
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());

            //caso o usuario exista no banco de dados ele retorna o usuario
            return  _context.Users.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass));
        }

        public User ValidateCredentials(string userName)
        {
            // verifica se existe um usuario com esse username e caso exista retorna ele
            return _context.Users.SingleOrDefault(u => (u.UserName == userName));
        }

        public User ValidateUser(UserRegisterVO user)
        {
            return _context.Users.SingleOrDefault(u => (u.UserName == user.UserName) && (u.Password == user.Password));
        }

        public async Task <bool> RevokeToken(string userName)
        {
            //verifica se o usuario existe e caso exista salvar ele em user
            var user = _context.Users.SingleOrDefault(u => (u.UserName == userName));
            //verfica se o usuario e nulo e caso seja nulo ele retorna um false
            if (user is null) return false;
            //atualizar o valor do refreshToken do usuario
            user.RefreshToken = null;
            //atualiza as informacoes no banco de dados
            await _context.SaveChangesAsync();
            return true;
        }

        //atualizar dados na tabela usuario
        public async Task<User> RefreshUserInfo(User user)
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
                    await _context.SaveChangesAsync();

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

        public bool Exists(long id)
        {
            return _context.Users.Any(p => p.Id.Equals(id));
        }

       
    }
}
