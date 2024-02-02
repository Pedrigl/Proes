using ProesBack.Domain.Entities;
using ProesBack.ViewModels;

namespace ProesBack.Interfaces
{
    public interface ILoginViewModelService
    {
        string GenerateJSONWebToken(Login login);
        string RefreshJSONWebToken(LoginViewModel login);
        string GetKey(int id);
        LoginViewModel GetLogin(long id);
        Login GetLogin(string username, string password);
        string Authenticate(Login login);
        void InsertLogin(Login login);
        void UpdateLogin(Login login);
        void DeleteLogin(long id);
    }
}
