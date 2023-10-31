using ProesBack.Domain.Entities;

namespace ProesBack.Interfaces
{
    public interface ILoginViewModelService
    {
        string RefreshJSONWebToken(string token);
        string GetKey(int id);
        Login GetLogin(int id);
        Login GetLogin(string username, string password);
        string Authenticate(Login login);
        void InsertLogin(Login login);
        void UpdateLogin(Login login);
        void DeleteLogin(int id);
    }
}
