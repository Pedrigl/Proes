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
        

        public UserViewModelService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public User GetUser(int id)
        {
            return _userRepository.Get(id);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
            _userRepository.Save();
        }

        public void DeleteUser(int id)
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
