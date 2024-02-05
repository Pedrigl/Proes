using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProesBack.Controllers;
using ProesBack.Infrastructure.Data.Repositories;
using ProesBack.Infrastructure.Web;
using ProesBack.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProesTests.ControllerTests
{
    [TestClass]
    public class LoginControllerTests
    {
        private LoginController _loginController;

        [TestInitialize]
        public void TestInitialize()
        {
            ILoginRepository loginRepository = new LoginRepository(GetFakeDbContext());
            IMapper mapper = GetMapper();
            ILoginViewModelService loginViewModelService = new LoginViewModelService(loginRepository, mapper);
            _loginController = new LoginController(loginViewModelService);
        }
    }
}
