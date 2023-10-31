using AutoMapper;
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
                var token = GenerateJSONWebToken();
                return token;
            }

            return null;
        }
        
        private string GenerateJSONWebToken()
        {
            var chaveDeSeguranca = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.GetKey()));
            var credenciaisDeAcesso = new SigningCredentials(chaveDeSeguranca, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                                issuer: "ProesBack",
                                audience: "ProesBack",
                                expires: DateTime.Now.AddMinutes(30),
                                signingCredentials: credenciaisDeAcesso
                                );
            return new JwtSecurityTokenHandler().WriteToken(token);
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
