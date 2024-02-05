using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProesBack.Domain.Interfaces;
using ProesBack.Infrastructure.Data.Repositories;
using ProesBack.Infrastructure.Web;
using ProesBack.Interfaces;
using ProesBack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProesTests.ViewModelServicesTests
{
    [TestClass]
    public class UserCourseViewModelServiceTests
    {
        private IUserCourseViewModelService _userCourseViewModelService;
        private IMapper _mapper;

        [TestInitialize]
        public void Initialize()
        {
            IUserCoursesRepository userCoursesRepository = new UserCourseRepository(GetFakeDbContext());
            ICourseRepository courseRepository = new CourseRepository(GetFakeDbContext());
            IUserRepository userRepository = new UserRepository(GetFakeDbContext());
            _mapper = GetMapper();

            _userCourseViewModelService = new UserCourseViewModelService(userCoursesRepository, courseRepository, userRepository, _mapper);


            _userCourseViewModelService.CreateCourseForUser(new UserCourseViewModel
            {
                Id = 1,
                UserId = 1,
                CourseId = 1,
                Attendance = 100,
                Grade = 10,
                IsDone = false
            });
        }

        [TestMethod]
        public void ShouldCreateCourseForUser()
        {
            _userCourseViewModelService.CreateCourseForUser(new UserCourseViewModel
            {
                Id = 2,
                UserId = 1,
                CourseId = 1,
                Attendance = 100,
                Grade = 10,
                IsDone = false
            });

            var userCourse = _userCourseViewModelService.GetUserCourse(2);
            userCourse.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldUpdateCourseForUser()
        {
            var userCourse = _userCourseViewModelService.GetUserCourse(1);
            userCourse.Grade = 9;
            _userCourseViewModelService.UpdateCourseForUser(userCourse.Id, userCourse);

            var updatedUserCourse = _userCourseViewModelService.GetUserCourse(1);
            updatedUserCourse.Grade.Should().Be(9);
        }

        [TestMethod]
        public void ShouldGetCourseForUserByUserId()
        {
            _userCourseViewModelService.CreateCourseForUser(new UserCourseViewModel
            {
                Id = 2,
                UserId = 1,
                CourseId = 1,
                Attendance = 100,
                Grade = 10,
                IsDone = false
            });

            var userCourse = _userCourseViewModelService.GetUserCoursesByUserId(1);
            userCourse.Count().Should().BeGreaterThan(1);
        }
    }
}
