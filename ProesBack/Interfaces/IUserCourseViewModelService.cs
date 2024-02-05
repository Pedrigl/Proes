using ProesBack.Domain.Models;
using ProesBack.ViewModels;

namespace ProesBack.Interfaces
{
    public interface IUserCourseViewModelService
    {
        void CreateCourseForUser(UserCourseViewModel userCourseViewModel);
        void DeleteCourseForUser(long id);
        void UpdateCourseForUser(long id, UserCourseViewModel userCourseViewModel);
        UserCourseViewModel GetUserCourse(long id);
        IEnumerable<UserCourseViewModel> GetUserCourses();
        IEnumerable<UserCourseViewModel> GetUserCoursesByUserId(long userId);
        UserCourseValidty IsUserCourseValid(UserCourseViewModel userCourse)
    }
}
