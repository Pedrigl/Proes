using ProesBack.Domain.Entities;

namespace ProesBack.Domain.Interfaces
{
    public interface ILoginRepository
    {
        Login Get(long id);
        Login Login(string username, string password);
        void Insert(Login login);
        void Update(long entityId,Login login);
        void Delete(long id);
        void Save();
    }
}
