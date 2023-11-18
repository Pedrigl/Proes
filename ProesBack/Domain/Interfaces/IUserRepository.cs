using ProesBack.Domain.Entities;

namespace ProesBack.Domain.Interfaces
{
    public interface IUserRepository
    {
        User GetByLoginId(int id);
        User Get(int userId);
        void Insert(User user);
        void Update(User user);
        void Delete(int id);
        void Save();
    }
}
