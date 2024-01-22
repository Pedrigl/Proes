using AutoMapper;
using ProesBack.Domain.Entities;
using ProesBack.Domain.Interfaces;
using ProesBack.Interfaces;

namespace ProesBack.Services
{
    public class UserViewModelService : IUserViewModelService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILoginRepository _loginRepository;

        public UserViewModelService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public User GetUserByLoginId(long loginId)
        {
            return _userRepository.GetByLoginId(loginId);
        }

        public User GetByUserId(long id)
        {
            return _userRepository.Get(id);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user.Id, user);
            _userRepository.Save();
        }

        public void DeleteUser(long id)
        {
            _userRepository.Delete(id);
            _userRepository.Save();
        }

        public void InsertUser(User user)
        {
            _userRepository.Insert(user);   
            _userRepository.Save();
        }

        public string UploadPicture(IFormFile picture)
        {
            return "";
        }
    }
}
