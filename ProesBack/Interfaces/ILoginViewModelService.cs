using ProesBack.Domain.Entities;

namespace ProesBack.Interfaces
{
    public interface ILoginViewModelService
    {
        void Login(string username, string password);
        void Insert(Login login);
        void Update(Login login);
        void Delete(int id);
    }
}
