﻿using AutoMapper;
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
    public class AssignmentTests
    {
        private IMapper _mapper;
        private IAssignmentViewModelService _assignmentViewModelService;

        [TestInitialize]
        public void Initialize()
        {
            IAssignmentRepository assignmentRepository = new AssignmentRepository(GetFakeDbContext());
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            }));
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
        public void CreateAssignmentTest()
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
        public void UpdateAssignmentTest()
        {
            var assignment = _assignmentViewModelService.GetAssignmentById(1);
            assignment.Title = "testUpdate";
            _assignmentViewModelService.UpdateAssignment(assignment);

            var updatedAssignment = _assignmentViewModelService.GetAssignmentById(1);
            updatedAssignment.Title.Should().Be("testUpdate");
        }

        [TestMethod]
        public void GetAssignmentTest()
        {
            var assignment = _assignmentViewModelService.GetAssignmentById(1);
            assignment.Should().NotBeNull();
        }

        [TestMethod]
        public void DeleteAssignmentTest()
        {
            _assignmentViewModelService.DeleteAssignment(1);
            var assignment = _assignmentViewModelService.GetAssignmentById(1);
            assignment.Should().BeNull();
        }

        [TestMethod]
        public void GetAssignmentsByCourseIdTest()
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