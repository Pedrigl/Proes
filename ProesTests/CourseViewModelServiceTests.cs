using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProesBack.Infrastructure.Data.Repositories;
using ProesBack.Infrastructure.Web;
using ProesBack.Interfaces;
using ProesBack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProesTests
{
    [TestClass]
    public class CourseViewModelServiceTests
    {
        private ICourseViewModelService _courseViewModelService;
        private IMapper _mapper;

        [TestInitialize]
        public void Initialize()
        {
            IConfiguration configuration = GetConfiguration();
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            }));

            ICourseRepository courseRepository = new CourseRepository(GetFakeDbContext());
            _courseViewModelService = new CourseViewModelService(_mapper,courseRepository);

            _courseViewModelService.CreateCourse(new CourseViewModel
            {
                Id = 1,
                Title = "testInit",
                Description = "testInit",
                TeacherId = 1,
                CreationDate = DateTime.Now,
                Semester = ProesBack.Domain.Enums.Semesters.First
            });
        }

        [TestMethod]
        public void ShouldCreateCourse()
        {
            _courseViewModelService.CreateCourse(new CourseViewModel
            {
             Id = 2,
             Title = "test",
             Semester = ProesBack.Domain.Enums.Semesters.Nineth,
             CreationDate = DateTime.Now,
             Description = "test",
             TeacherId = 1
            });

            var course = _courseViewModelService.GetCourse(1);
            course.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldGetCourse()
        {
            var course = _courseViewModelService.GetCourse(1);
            course.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldDeleteCourse()
        {
            _courseViewModelService.DeleteCourse(1);
            var course = _courseViewModelService.GetCourse(1);
            course.Should().BeNull();
        }

        [TestMethod]
        public void ShouldUpdateCourse()
        {
            var course = _courseViewModelService.GetCourse(1);
            course.Title = "testUpdate";
            _courseViewModelService.UpdateCourse(1, course);
            var updatedCourse = _courseViewModelService.GetCourse(1);
            updatedCourse.Title.Should().Be("testUpdate");
        }


    }
}
