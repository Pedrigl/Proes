using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using ProesBack.Domain.Entities;
using ProesBack.Domain.Interfaces;
using ProesBack.Infrastructure.Data.Common;
using ProesBack.Interfaces;
using ProesBack.ViewModels;
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

        public string Authenticate(LoginViewModel login)
        {
            var mappedLogin = _mapper.Map<Login>(login);
            var credentials = _loginRepository.Login(login.Username, login.Password);
            
            if (credentials != null)
            {
                var token = GenerateJSONWebToken(mappedLogin);
                return token;
            }

            return null;
        }
        
        public string GenerateJSONWebToken(Login login)
        {
            var chaveDeSeguranca = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Key));
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

        public string RefreshJSONWebToken(LoginViewModel login)
        {
            var mappedLogin = _mapper.Map<Login>(login);

            var chave = Encoding.ASCII.GetBytes(Settings.Key);

            var parametrosDeValidacao = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(chave),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false
            };

            SecurityToken tokenDeSeguranca;

            var principal = new JwtSecurityTokenHandler().ValidateToken(mappedLogin.Token, parametrosDeValidacao, out tokenDeSeguranca);

            var jwtSecurityToken = tokenDeSeguranca as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Token inválido");

            if(mappedLogin == null)
                throw new SecurityTokenException("Usuario inválido");

            mappedLogin.Token = GenerateJSONWebToken(mappedLogin);

            mappedLogin.TokenExpiration = DateTime.Now.AddMinutes(30);
            _loginRepository.Update(mappedLogin.Id, mappedLogin);
            _loginRepository.Save();

            return mappedLogin.Token;
        }

        public string GetKey(int id)
        {
            var login = _loginRepository.Get(id);
            var key = login.Token;
            return key;
        }

        public LoginViewModel GetLogin(long id)
        {
            var login = _loginRepository.Get(id);
            var loginViewModel = _mapper.Map<LoginViewModel>(login);
            return loginViewModel;
        }
        public LoginViewModel GetLogin(string username, string password)
        {
            var login = _loginRepository.Login(username, password);
            return _mapper.Map<LoginViewModel>(login);
        }
        public void InsertLogin(LoginViewModel login)
        {
            var mappedLogin = _mapper.Map<Login>(login);
            _loginRepository.Insert(mappedLogin);
            _loginRepository.Save();
        }

        public void UpdateLogin(LoginViewModel login)
        {
            var mappedLogin = _mapper.Map<Login>(login);
            _loginRepository.Update(login.Id,mappedLogin);
            _loginRepository.Save();
        }

        public void DeleteLogin(long id)
        {
            _loginRepository.Delete(id);
            _loginRepository.Save();
        }
    }
}
