using ProesBack.Domain.Entities;

namespace ProesBack.Interfaces
{
    public interface ILoginViewModelService
    {
        Login GetLogin(int id);
        Login GetLogin(string username, string password);
        string GenerateToken(Login login);
        void InsertLogin(Login login);
        void UpdateLogin(Login login);
        void DeleteLogin(int id);
    }
}
