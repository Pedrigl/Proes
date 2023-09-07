using ProesBack.Domain.Entities;

namespace ProesBack.Domain.Interfaces
{
    public interface ILoginRepository
    {
        Login Login(string username, string password);
        void Insert(Login login);
        void Update(Login login);
        void Delete(int id);
        void Save();
    }
}
