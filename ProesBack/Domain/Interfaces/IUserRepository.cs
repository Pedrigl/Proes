using ProesBack.Domain.Entities;

namespace ProesBack.Domain.Interfaces
{
    public interface IUserRepository
    {
        User GetByLoginId(long id);
        User Get(long userId);
        void Insert(User user);
        void Update(long entityId, User user);
        void Delete(long id);
        void Save();
    }
}
