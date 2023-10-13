using ProesBack.Domain.Entities;

namespace ProesBack.Interfaces
{
    public interface IUserViewModelService
    {
        User GetUser(int id);

        void UpdateUser(User user);

        void DeleteUser(int id);

        void InsertUser(User user);
    }
}
