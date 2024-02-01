using AutoMapper;
using ProesBack.Domain.Entities;
using ProesBack.Domain.Interfaces;
using ProesBack.Interfaces;
using ProesBack.ViewModels;

namespace ProesBack.Services
{
    public class UserCourseViewModelService : IUserCourseViewModelService
    {
        private readonly IUserCoursesRepository _userCoursesRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserCourseViewModelService(IUserCoursesRepository userCoursesRepository, ICourseRepository courseRepository, IUserRepository userRepository, IMapper mapper)
        {
            _userCoursesRepository = userCoursesRepository;
            _courseRepository = courseRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void CreateCourseForUser(UserCourseViewModel userCourseViewModel)
        {
            var userCourseMapped = _mapper.Map<UserCourseViewModel, UserCourse>(userCourseViewModel);
            _userCoursesRepository.Insert(userCourseMapped);
            _userCoursesRepository.Save();
        }

        public void DeleteCourseForUser(long id)
        {
            _userCoursesRepository.Delete(id);
            _userCoursesRepository.Save();
        }

        public void UpdateCourseForUser(long id, UserCourseViewModel userCourseViewModel)
        {
            var userCourseMapped = _mapper.Map<UserCourseViewModel, UserCourse>(userCourseViewModel);
            _userCoursesRepository.Update(id, userCourseMapped);
            _userCoursesRepository.Save();
        }

        public IEnumerable<UserCourseViewModel> GetUserCoursesByUserId(long userId)
        {
            var userCourses = _userCoursesRepository.GetAll().Where(userCourse => userCourse.UserId == userId);
            return _mapper.Map<IEnumerable<UserCourse>, IEnumerable<UserCourseViewModel>>(userCourses);
        }

        public UserCourseViewModel GetUserCourse(long id)
        {
            var userCourse = _userCoursesRepository.Get(id);
            return _mapper.Map<UserCourse, UserCourseViewModel>(userCourse);
        }

        public IEnumerable<UserCourseViewModel> GetUserCourses()
        {
            var userCourses = _userCoursesRepository.GetAll();
            return _mapper.Map<IEnumerable<UserCourse>, IEnumerable<UserCourseViewModel>>(userCourses);
        }
    }
}
