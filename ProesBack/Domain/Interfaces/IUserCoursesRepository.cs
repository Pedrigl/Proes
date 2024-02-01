using ProesBack.Domain.Entities;

namespace ProesBack.Domain.Interfaces
{
    public interface IUserCoursesRepository
    {
        IEnumerable<UserCourse> GetAll();
        UserCourse Get(long id);
        void Insert(UserCourse userCourses);
        void Update(long entityId, UserCourse userCourses);
        void Delete(long id);
        void Save();
    }
}
