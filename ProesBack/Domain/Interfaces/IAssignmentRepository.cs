using ProesBack.Domain.Entities;

namespace ProesBack.Domain.Interfaces
{
    public interface IAssignmentRepository
    {
        Assignment Get(long id);
        IEnumerable<Assignment> GetAll();
        void Insert(Assignment course);
        void Update(long entityId, Assignment course);
        void Delete(long id);
        void Save();
    }
}
