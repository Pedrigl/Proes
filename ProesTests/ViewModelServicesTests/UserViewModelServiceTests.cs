﻿using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProesBack.Infrastructure.Data.Common;
using ProesBack.Infrastructure.Data.Repositories;
using ProesBack.Infrastructure.Web;
using ProesBack.Interfaces;
using ProesBack.ViewModels;
using System.Net;

namespace ProesTests.ViewModelServicesTests
{
    [TestClass]
    public class UserViewModelServiceTests
    {
        private IUserViewModelService _userViewModelService;
        private IMapper _mapper;

        [TestInitialize]
        public void Initialize()
        {
            IConfiguration configuration = GetConfiguration();

            Settings.Setup(configuration);

            _mapper = GetMapper();

            IUserRepository _userRepository = new UserRepository(GetFakeDbContext());
            _userViewModelService = new UserViewModelService(_userRepository, _mapper);

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

        public void ShouldCreateUser()
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
        public void ShouldGetUser()
        {
            var user = _userViewModelService.GetUserByLoginId(1);
            user.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldUpdateUser()
        {
            var user = _userViewModelService.GetUserByLoginId(1);
            user.Name = "testUpdate";
            _userViewModelService.UpdateUser(user);
            var updatedUser = _userViewModelService.GetUserByLoginId(1);

            updatedUser.Name.Should().Be("testUpdate");
        }

        [TestMethod]
        public void ShouldDeleteUser()
        {
            _userViewModelService.DeleteUser(1);
            var user = _userViewModelService.GetUserByLoginId(1);
            user.Should().BeNull();
        }

        [TestMethod]
        public void ShouldUploadPicture()
        {

            var pictureUpload = _userViewModelService.UploadPicture(1, CreateBlankPicture());
            pictureUpload.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldGetLinkToPicture()
        {
            var pictureLink = _userViewModelService.GetLinkToPicture(1);
            HttpClient client = new HttpClient();
            var request = client.GetAsync(pictureLink);
            request.Wait();
            var response = request.Result;
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }


    }
}
