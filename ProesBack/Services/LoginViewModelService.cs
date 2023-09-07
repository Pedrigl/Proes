using AutoMapper;
using ProesBack.Domain.Entities;
using ProesBack.Domain.Interfaces;
using ProesBack.Interfaces;

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

        public void Login(string username, string password)
        {
            _loginRepository.Login(username, password);
            //fazer autenticação
        }

        public void Insert(Login login)
        {
            _loginRepository.Insert(login);
            _loginRepository.Save();
        }

        public void Update(Login login)
        {
            _loginRepository.Update(login);
            _loginRepository.Save();
        }

        public void Delete(int id)
        {
            _loginRepository.Delete(id);
            _loginRepository.Save();
        }
    }
}
