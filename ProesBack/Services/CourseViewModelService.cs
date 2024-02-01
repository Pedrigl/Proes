using AutoMapper;
using ProesBack.Domain.Entities;
using ProesBack.Domain.Interfaces;
using ProesBack.Interfaces;
using ProesBack.ViewModels;

namespace ProesBack.Services
{
    public class CourseViewModelService : ICourseViewModelService
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        public CourseViewModelService(IMapper mapper, ICourseRepository courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public IEnumerable<CourseViewModel> GetCourses()
        {
            var courses = _courseRepository.GetAll();
            return _mapper.Map<IEnumerable<CourseViewModel>>(courses);
        }

        public CourseViewModel GetCourse(long id)
        {
            var course = _courseRepository.Get(id);
            return _mapper.Map<CourseViewModel>(course);
        }

        public void CreateCourse(CourseViewModel courseViewModel)
        {
            var course = _mapper.Map<Course>(courseViewModel);
            _courseRepository.Insert(course);
            _courseRepository.Save();
        }

        public void UpdateCourse(long id, CourseViewModel courseViewModel)
        {
            var course = _mapper.Map<Course>(courseViewModel);
            _courseRepository.Update(id, course);
            _courseRepository.Save();
        }

        public void DeleteCourse(long id)
        {
            _courseRepository.Delete(id);
            _courseRepository.Save();
        }
    }
}
