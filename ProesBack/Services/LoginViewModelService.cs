using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using ProesBack.Domain.Entities;
using ProesBack.Domain.Interfaces;
using ProesBack.Infrastructure.Data.Common;
using ProesBack.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProesBack.Services
{
    public class LoginViewModelService : ILoginViewModelService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;

        public LoginViewModelService(ILoginRepository loginRepository, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }

        public string Authenticate(Login login)
        {
            var credentials = _loginRepository.Login(login.Username, login.Password);
            //fazer autenticação
            if (credentials != null)
            {
                var token = GenerateJSONWebToken(login);
                return token;
            }

            return null;
        }
        
        private string GenerateJSONWebToken(Login login)
        {
            var chaveDeSeguranca = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.GetKey()));
            var credenciaisDeAcesso = new SigningCredentials(chaveDeSeguranca, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.Username),
                new Claim(ClaimTypes.Role, login.UserType.ToString()),
                new Claim("userId", login.Id.ToString()),
            };

            var token = new JwtSecurityToken(
                                issuer: "ProesBack",
                                audience: "ProesBack",
                                claims: claims,
                                expires: DateTime.Now.AddMinutes(30),
                                signingCredentials: credenciaisDeAcesso
                                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string RefreshJSONWebToken(string token)
        {
            var gerenciadorDeToken = new JwtSecurityToken();
            var chave = Encoding.ASCII.GetBytes(Settings.GetKey());

            var parametrosDeValidacao = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(chave),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false
            };

            SecurityToken tokenDeSeguranca;

            var principal = new JwtSecurityTokenHandler().ValidateToken(token, parametrosDeValidacao, out tokenDeSeguranca);

            var jwtSecurityToken = tokenDeSeguranca as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Token inválido");

            var loginId = int.Parse(principal.FindFirst("userId").Value);

            var login = _loginRepository.Get(loginId);

            if(login == null)
                throw new SecurityTokenException("Usuario inválido");

            login.Token = GenerateJSONWebToken(login);

            login.TokenExpiration = (int)DateTime.Now.AddMinutes(30).Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            _loginRepository.Save();

            return login.Token;
        }

        public string GetKey(int id)
        {
            var login = _loginRepository.Get(id);
            var key = login.Token;
            return key;
        }

        public Login GetLogin(int id)
        {
            return _loginRepository.Get(id);
        }
        public Login GetLogin(string username, string password)
        {
            return _loginRepository.Login(username, password);
        }
        public void InsertLogin(Login login)
        {
            _loginRepository.Insert(login);
            _loginRepository.Save();
        }

        public void UpdateLogin(Login login)
        {
            _loginRepository.Update(login);
            _loginRepository.Save();
        }

        public void DeleteLogin(int id)
        {
            _loginRepository.Delete(id);
            _loginRepository.Save();
        }
    }
}
