using ProesBack.Interfaces;
using ProesBack.Infrastructure.Data.Repositories;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProesBack.ViewModels;
using ProesBack.Domain.Enums;
using ProesBack.Infrastructure.Web;
namespace ProesTests
{
    [TestClass]
    public class LoginTests
    {
        private  ILoginViewModelService _loginViewModelService;
        private ILoginRepository _loginRepository;
        private IMapper _mapper;

        [TestInitialize]
        public void Initialize()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            }));
            _loginRepository = new LoginRepository(GetFakeDbContext());
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
        public void CreateStudentLoginTest()
        {
            _loginViewModelService.InsertLogin(new Login { 
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
        public void UpdateLoginTest()
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
        public void AuthenticateTest()
        {
            var login = _loginViewModelService.GetLogin(1);
            var mappedLogin = _mapper.Map<LoginViewModel, Login>(login);
            var token = _loginViewModelService.Authenticate(mappedLogin);
            token.Should().NotBeNull();
        }

        [TestMethod]
        public void RefreshTokenTest()
        {
            var login = _loginViewModelService.GetLogin(1);

            var token = login.Token;

            var newToken = _loginViewModelService.RefreshJSONWebToken(login);

            token.Should().NotBe(newToken);
        }



        [TestMethod]
        public void DeleteLoginTest()
        {
            _loginViewModelService.DeleteLogin(1);
            var login = _loginViewModelService.GetLogin(1);
            login.Should().BeNull();
        }

        
    }
}
