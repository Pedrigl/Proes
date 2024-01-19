using ProesBack.Domain.Entities;
using ProesBack.ViewModels;

namespace ProesBack.Interfaces
{
    public interface ILoginViewModelService
    {
        string RefreshJSONWebToken(string token);
        string GetKey(int id);
        LoginViewModel GetLogin(long id);
        Login GetLogin(string username, string password);
        string Authenticate(Login login);
        void InsertLogin(Login login);
        void UpdateLogin(Login login);
        void DeleteLogin(long id);
    }
}
