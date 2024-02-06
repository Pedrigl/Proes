using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProesBack.Controllers;
using ProesBack.Domain.Enums;
using ProesBack.Infrastructure.Data.Common;
using ProesBack.Infrastructure.Data.Repositories;
using ProesBack.Infrastructure.Web;
using ProesBack.Interfaces;
using ProesBack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
namespace ProesTests.ControllerTests
{
    [TestClass]
    public class LoginControllerTests
    {
        private LoginController _loginController;
        private HttpClient _client;

        [TestInitialize]
        public void TestInitialize()
        {
            _client = new HttpClient();
            IConfiguration configuration = GetConfiguration();
            Settings.Setup(configuration);
            ILoginRepository loginRepository = new LoginRepository(GetFakeDbContext());
            IMapper mapper = GetMapper();
            ILoginViewModelService loginViewModelService = new LoginViewModelService(loginRepository, mapper);
            _loginController = new LoginController(loginViewModelService);

            _loginController.Register(new Login {
            Username = "testInit",
            Password = "testInit",
            UserType = UserType.admin
            }).Wait();
        }


        [TestMethod]
        public void ShouldLogIn()
        {
            var login = _loginController.Login("testInit", "testInit");
            login.Wait();

            var result = login.Result as OkObjectResult;
            result.Value.Should().BeOfType<LoginViewModel>();
        }

        [TestMethod]
        public void ShouldNotLogIn()
        {
            var login = _loginController.Login("testInit", "testInit2");
            login.Wait();

            var result = login.Result as BadRequestObjectResult;
            result.Value.Should().Be("Username or password is incorrect");
        }

        [TestMethod]
        public void ShouldRegister()
        {
            var register = _loginController.Register(new Login {
                Id = 2,
                Username = "testRegister",
                Password = "testRegister",
                UserType = UserType.admin
            });

            register.Wait();

            var login = _loginController.Login("testRegister", "testRegister");
            login.Wait();

            var result = login.Result as OkObjectResult;
            result.Value.Should().BeOfType<LoginViewModel>();
        }

        [TestMethod]
        public void ShouldNotRegister()
        {
            var register = _loginController.Register(new Login
            {
                Id = 2,
                Username = "testInit",
                Password = "testInit",
                UserType = UserType.admin
            });

            register.Wait();

            var result = register.Result as BadRequestObjectResult;
            result.Value.Should().Be("testInit already exists");
        }

        [TestMethod]
        public void ShouldDeleteLogin()
        {
            var delete = _loginController.Delete(1);
            delete.Wait();

            var login = _loginController.Login("testInit", "testInit");
            login.Wait();

            var result = login.Result as BadRequestObjectResult;
            result.Value.Should().Be("Username or password is incorrect");
        }

        [TestMethod]
        public void ShouldNotDeleteLogin()
        {
            var delete = _loginController.Delete(2);
            delete.Wait();

            var result = delete.Result as BadRequestObjectResult;
            result.Value.Should().Be("Login not found");
        }

        [TestMethod]
        public void ShouldRefreshToken()
        {
            var login = _loginController.Login("testInit", "testInit");
            login.Wait();

            var result = login.Result as OkObjectResult;
            var loginViewModel = result.Value as LoginViewModel;

            var refresh = _loginController.Refresh(loginViewModel);

            refresh.Wait();

            var refreshResult = refresh.Result as OkObjectResult;
            refreshResult.Value.Should().BeOfType<string>();
        }
    }
}
