using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProesBack.Infrastructure.Data.Repositories;
using ProesBack.Interfaces;
using ProesBack.ViewModels;

namespace ProesTests
{
    [TestClass]
    public class UserTests
    {
        private readonly IUserViewModelService _userViewModelService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserTests(IMapper mapper)
        {
            _mapper = mapper;
            IUserRepository _userRepository = new UserRepository(GetFakeDbContext());
            IUserViewModelService _userViewModelService = new UserViewModelService(_userRepository, _mapper);
        }

        [TestInitialize]
        public void Initialize()
        {
            _userViewModelService.InsertUser(new UserViewModel
            {
                Id = 1,
                Name = "testInit",
                Email = "testInit@test.com",
                BirthDate = DateTime.Now,
                LoginId = 1,
                Semester = ProesBack.Domain.Enums.Semesters.First
            });
        }

        [TestMethod]

        public void CreateUserTest()
        {
            _userViewModelService.InsertUser(new UserViewModel
            {
                Id = 2,
                Name = "test",
                Email = "test@test.com",
                BirthDate = DateTime.Now,
                LoginId = 2,
                Semester = ProesBack.Domain.Enums.Semesters.First
            });

            var user = _userViewModelService.GetByUserId(2);
            user.Should().NotBeNull();
        }

        [TestMethod]
        public void GetUserTest()
        {
            var user = _userViewModelService.GetUserByLoginId(1);
            user.Should().NotBeNull();
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            var user = _userViewModelService.GetUserByLoginId(1);
            user.Name = "testUpdate";
            _userViewModelService.UpdateUser(user);
            var updatedUser = _userViewModelService.GetUserByLoginId(1);

            updatedUser.Name.Should().Be("testUpdate");
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            _userViewModelService.DeleteUser(1);
            var user = _userViewModelService.GetUserByLoginId(1);
            user.Should().BeNull();
        }

        [TestMethod]
        public void UploadPictureTest()
        {
            
            var pictureUpload = _userViewModelService.UploadPicture(1, CreateBlankPicture());
            pictureUpload.Should().NotBeNull();
        }

        [TestMethod]
        public void GetLinkToPictureTest()
        {
            var pictureLink = _userViewModelService.GetLinkToPicture(1);
            HttpClient client = new HttpClient();
            var request = client.GetAsync(pictureLink);
            request.Wait();
            var response = request.Result;
            response.Should().NotBeNull();
        }


    }
}
