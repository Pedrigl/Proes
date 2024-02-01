using ProesBack.Domain.Entities;

namespace ProesBack.Domain.Interfaces
{
    public interface IAssignmentRepository
    {
        Assignment Get(long id);
        ICollection<Assignment> GetByCourseId(long courseId);
        IEnumerable<Assignment> GetAll();
        void Insert(Assignment course);
        void Update(long entityId, Assignment course);
        void Delete(long id);
        void Save();
    }
}
