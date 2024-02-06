using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

namespace ProesTests.ViewModelServicesTests
{
    [TestClass]
    public class AssignmentViewModelServiceTests
    {
        private IMapper _mapper;
        private IAssignmentViewModelService _assignmentViewModelService;

        [TestInitialize]
        public void Initialize()
        {
            IConfiguration configuration = GetConfiguration();
            Settings.Setup(configuration);
            IAssignmentRepository assignmentRepository = new AssignmentRepository(GetFakeDbContext());
            _mapper = GetMapper();
            _assignmentViewModelService = new AssignmentViewModelService(assignmentRepository, _mapper);

            _assignmentViewModelService.CreateAssignment(new AssignmentViewModel
            {
                Id = 1,
                Title = "testInit",
                Description = "testInit",
                CourseId = 1,
                CreationDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7)
            });
        }

        [TestMethod]
        public void ShouldCreateAssignment()
        {
            _assignmentViewModelService.CreateAssignment(new AssignmentViewModel
            {
                Id = 2,
                Title = "test",
                Description = "test",
                CourseId = 1,
                CreationDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7)
            });

            var assignment = _assignmentViewModelService.GetAssignmentById(2);
            assignment.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldUpdateAssignment()
        {
            var assignment = _assignmentViewModelService.GetAssignmentById(1);
            assignment.Title = "testUpdate";
            _assignmentViewModelService.UpdateAssignment(assignment);

            var updatedAssignment = _assignmentViewModelService.GetAssignmentById(1);
            updatedAssignment.Title.Should().Be("testUpdate");
        }

        [TestMethod]
        public void ShouldGetAssignmentByItsOwnId()
        {
            var assignment = _assignmentViewModelService.GetAssignmentById(1);
            assignment.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldDeleteAssignment()
        {
            _assignmentViewModelService.DeleteAssignment(1);
            var assignment = _assignmentViewModelService.GetAssignmentById(1);
            assignment.Should().BeNull();
        }

        [TestMethod]
        public void ShouldGetAssignmentsByCourseId()
        {
            _assignmentViewModelService.CreateAssignment(new AssignmentViewModel
            {
                Id = 2,
                Title = "test",
                Description = "test",
                CourseId = 1,
                CreationDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7)
            });

            var assignments = _assignmentViewModelService.GetAssignmentsByCourseId(1);
            assignments.Count().Should().BeGreaterThan(1);
        }
    }
}
