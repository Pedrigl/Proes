using ProesBack.ViewModels;

namespace ProesBack.Interfaces
{
    public interface ICourseViewModelService
    {
        IEnumerable<CourseViewModel> GetCourses();
        CourseViewModel GetCourse(long id);
        void CreateCourse(CourseViewModel courseViewModel);
        void UpdateCourse(long id, CourseViewModel courseViewModel);
        void DeleteCourse(long id);
    }
}
