using ProesBack.Domain.Interfaces;
using ProesBack.Interfaces;

namespace ProesBack.Services
{
    public class UserCourseViewModelService : IUserCourseViewModelService
    {
        private readonly IUserCoursesRepository _userCoursesRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;

        public UserCourseViewModelService(IUserCoursesRepository userCoursesRepository, ICourseRepository courseRepository, IUserRepository userRepository)
        {
            _userCoursesRepository = userCoursesRepository;
            _courseRepository = courseRepository;
            _userRepository = userRepository;
        }


    }
}
