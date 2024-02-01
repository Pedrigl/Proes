using ProesBack.Domain.Entities;

namespace ProesBack.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Course Get(long id);
        IEnumerable<Course> GetAll();
        void Insert(Course course);
        void Update(long entityId, Course course);
        void Delete(long id);
        void Save();
    }
}
