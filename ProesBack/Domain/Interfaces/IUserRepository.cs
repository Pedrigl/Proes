using ProesBack.Domain.Entities;

namespace ProesBack.Domain.Interfaces
{
    public interface IUserRepository
    {
        User Get(int loginId);
        void Insert(User user);
        void Update(User user);
        void Delete(int id);
        void Save();
    }
}
