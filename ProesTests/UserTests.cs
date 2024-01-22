using Xunit;
using Moq;
using System.IO;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using ProesBack.Domain.Entities;
using ProesBack.Domain.Interfaces;
using ProesBack.Interfaces;
using ProesBack.Infrastructure.Web;
using ProesTests;

namespace ProesBack.Services.Tests
{
    public class UserViewModelServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly IMapper _mapperMock;
        private readonly User _testUser;
        private readonly UserViewModelService _testUserService;

        public UserViewModelServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();

            _mapperMock = new MapperConfiguration(cfg =>cfg.AddProfile(new AutoMapping())).CreateMapper();

            _testUser = new User
            {
                Id = 1,
                Name = "testuser1"
            };

            _testUserService = new UserViewModelService(_userRepositoryMock.Object, _mapperMock);

        }

        [Fact]
        public void GetUserShouldReturnSingleUser()
        {
            //Arrange
            _userRepositoryMock.Setup(x => x.Get(_testUser.Id)).Returns(_testUser);

            //Act
            var result = _testUserService.GetByUserId(_testUser.Id);

            //Assert
            Assert.Equal(_testUser, result);
        }

        [Fact]
        public void UpdateUserShouldUpdateUser()
        {
            //Arrange
            _userRepositoryMock.Setup(x => x.Update(_testUser.Id,_testUser));

            //Act
            _testUserService.UpdateUser(_testUser);

            //Assert
            _userRepositoryMock.Verify(x => x.Save(), Times.Once);
        }

        [Fact]
        public void DeleteUserShouldDeleteUser()
        {
            //Arrange
            _userRepositoryMock.Setup(x => x.Delete(_testUser.Id));

            //Act
            _testUserService.DeleteUser(_testUser.Id);

            //Assert
            _userRepositoryMock.Verify(x => x.Save(), Times.Once);
        }

        [Fact]
        public void InsertUserShouldInsertUser()
        {
            //Arrange
            _userRepositoryMock.Setup(x => x.Insert(_testUser));
            

            //Act
            _testUserService.InsertUser(_testUser);

            //Assert
            _userRepositoryMock.Verify(x => x.Save(), Times.Once);
        }
        
    }
}
