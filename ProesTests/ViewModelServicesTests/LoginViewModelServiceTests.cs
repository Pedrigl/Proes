using ProesBack.Interfaces;
using ProesBack.Infrastructure.Data.Repositories;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProesBack.ViewModels;
using ProesBack.Domain.Enums;
using ProesBack.Infrastructure.Web;
using Microsoft.Extensions.Configuration;
using ProesBack.Infrastructure.Data.Common;
namespace ProesTests.ViewModelServicesTests
{
    [TestClass]
    public class LoginViewModelServiceTests
    {
        private ILoginViewModelService _loginViewModelService;
        private IMapper _mapper;

        [TestInitialize]
        public void Initialize()
        {
            IConfiguration configuration = GetConfiguration();
            Settings.Setup(configuration);

            _mapper = GetMapper();

            LoginRepository _loginRepository = new LoginRepository(GetFakeDbContext());
            _loginViewModelService = new LoginViewModelService(_loginRepository, _mapper);
            _loginViewModelService.InsertLogin(new Login
            {
                Id = 1,
                Username = "testInit",
                Password = "testInit",
                UserId = 0,
                UserType = UserType.admin
            });
        }

        [TestMethod()]
        public void ShouldCreateStudentLogin()
        {
            _loginViewModelService.InsertLogin(new Login
            {
                Id = 2,
                Username = "test",
                Password = "test",
                UserId = 0,
                UserType = UserType.student
            });

            var login = _loginViewModelService.GetLogin(2);

            login.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldGetLogin()
        {
            var login = _loginViewModelService.GetLogin("testInit", "testInit");
            login.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldGenerateJSONWebToken()
        {
            var login = _loginViewModelService.GetLogin("testInit", "testInit");

            var token = _loginViewModelService.GenerateJSONWebToken(login);
            token.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldUpdateLogin()
        {
            var login = _loginViewModelService.GetLogin(1);
            login.UserType = UserType.admin;
            login.Username = "updated Username";
            var mappedLogin = _mapper.Map<LoginViewModel, Login>(login);
            mappedLogin.Password = "updated Password";

            _loginViewModelService.UpdateLogin(mappedLogin);

            var updatedLogin = _loginViewModelService.GetLogin(1);

            updatedLogin.Should().NotBe(mappedLogin);
        }

        [TestMethod]
        public void ShouldAuthenticateLogin()
        {
            var login = _loginViewModelService.GetLogin("testInit", "testInit");
            var token = _loginViewModelService.Authenticate(login);
            token.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldDeleteLogin()
        {
            _loginViewModelService.DeleteLogin(1);
            var login = _loginViewModelService.GetLogin(1);
            login.Should().BeNull();
        }


    }
}
