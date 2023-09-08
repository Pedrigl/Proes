using ProesBack.Domain.Entities;

namespace ProesBack.Interfaces
{
    public interface ILoginViewModelService
    {
        Login Get(string username, string password);
        string GenerateToken(Login login);
        void Insert(Login login);
        void Update(Login login);
        void Delete(int id);
    }
}
