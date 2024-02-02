using AutoMapper;
using ProesBack.Domain.Entities;
using ProesBack.Domain.Interfaces;
using ProesBack.Interfaces;
using ProesBack.ViewModels;
using Azure;
using ProesBack.Services.Common;
using ProesBack.Infrastructure.Data.Common;
using ProesBack.Interfaces.Common;
using Azure.Storage.Files.Shares.Models;
namespace ProesBack.Services
{
    public class UserViewModelService : IUserViewModelService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILoginRepository _loginRepository;

        private IShareService ShareService 
        {
            get => new ShareService(Settings.ProesFilesUrl,"proesfiles");
        }

        public UserViewModelService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserViewModel GetUserByLoginId(long loginId)
        {
            var user = _userRepository.GetByLoginId(loginId);
            return _mapper.Map<User,UserViewModel>(user);
        }

        public UserViewModel GetByUserId(long id)
        {
            var user = _userRepository.Get(id);
            return _mapper.Map<User, UserViewModel>(user);
        }

        public void UpdateUser(UserViewModel user)
        {
            var mappedUser = _mapper.Map<UserViewModel, User>(user);
            _userRepository.Update(mappedUser.Id, mappedUser);
            _userRepository.Save();
        }

        public void DeleteUser(long id)
        {
            _userRepository.Delete(id);
            _userRepository.Save();
        }

        public void InsertUser(UserViewModel user)
        {
            var mappedUser = _mapper.Map<UserViewModel, User>(user);
            _userRepository.Insert(mappedUser);   
            _userRepository.Save();
        }

        public ShareFileUploadInfo UploadPicture(long userId, IFormFile picture)
        {
            var pictureStream = picture.OpenReadStream();
            return ShareService.UploadProfilePicture($"Id:{userId}_ProfilePicutre", pictureStream);
            
        }

        public string GetLinkToPicture(long userId)
        {
            return ShareService.GetAuthorizedLinkToProfilePicture($"Id:{userId}_ProfilePicutre");
        }           


    }
}
