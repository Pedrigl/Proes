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
        LoginViewModel GetLogin(string username, string password);
        string Authenticate(LoginViewModel login);
        void InsertLogin(LoginViewModel login);
        void UpdateLogin(LoginViewModel login);
        void DeleteLogin(long id);
    }
}
