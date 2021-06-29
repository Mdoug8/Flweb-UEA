using Flweb.Business.Interface;
using Flweb.Configurations;
using Flweb.Data.VO;
using Flweb.Repository.Interface;
using Flweb.Services.Interface;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Flweb.Business.Implementation
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfiguration _configuration;

        private IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public LoginBusinessImplementation(TokenConfiguration configuration, IUserRepository repository, ITokenService tokenService)
        {
            _configuration = configuration;
            _repository = repository;
            _tokenService = tokenService;
        }

        public TokenVO ValidateCredentials(UserVO userCredentials)
        {
            //verifica se esse usuario existe no banco, caso exista ele retorna o usuario do banco para a variavel user
            var user = _repository.ValidateCredentials(userCredentials);

            if (user == null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            // gera um acessToken
            var accessToken = _tokenService.GenerateAccessToken(claims);
            // gera um refreshToken
            var refreshToken = _tokenService.GenerateRefreshToken();

            //salva o refreshToken gerado no atributo de refreshToken do usuario
            user.RefreshToken = refreshToken;

            //salva no atributo de RefreshTokenExpiryTime do usuario uma data de expiracao 
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            //atualiza as informacoes alteradas do usuario no banco 
            _repository.RefreshUserInfo(user);

            //pega a data atual e salva na variavel createDate
            DateTime createDate = DateTime.Now;

            // cria uma data de expiracao e salva em expirationDate
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            // retorna um token 
            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );
        }

        public TokenVO ValidateCredentials(TokenVO token)
        {
            //pega o acessToken do token e coloca na variavel
            var accessToken = token.AccessToken;

            //pega o refreshToken do token e coloca na variavel 
            var refreshToken = token.RefreshToken;

            //verifica a validade do token 
            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

            // verifica o username referente ao token
            var username = principal.Identity.Name;

            //verifica se o usuario existe na tabela de dados e caso exista ele retorna pra user
            var user = _repository.ValidateCredentials(username);

            // verifica a existencia do usuario
            //verifica se o refreshToken do usuario e igual ao que veio do token
            //verifica se o RefreshTokenExpiryTime do usuario é menor ou igual a data e hora atual
            if (user == null ||
                user.RefreshToken != refreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.Now) return null;

            //retorna um token gerado e salva na variavel acessToken
            accessToken = _tokenService.GenerateAccessToken(principal.Claims);

            //retorna um refreshToken gerado e salva na variavel refreshToken
            refreshToken = _tokenService.GenerateRefreshToken();

            //atualiza o valor de refreshToken do usuario
            user.RefreshToken = refreshToken;

            //salva essa atualizacao no banco de dados
            _repository.RefreshUserInfo(user);

            //pega a data atual
            DateTime createDate = DateTime.Now;

            //gera uma nova data de expiracao
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            //retorna um novo token com as novas informacoes
            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );
        }

        public bool RevokeToken(string userName)
        {
            // revoga o token
            return _repository.RevokeToken(userName);
        }
    }
}
