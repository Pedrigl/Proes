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

        public string GenerateToken(Login login)
        {
            var credentials = _loginRepository.Login(login.Username, login.Password);
            //fazer autenticação
            if (credentials != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                
                var key = Encoding.ASCII.GetBytes(Settings.GetKey());
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, credentials.Username.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(3),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                           SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }

            return null;
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
