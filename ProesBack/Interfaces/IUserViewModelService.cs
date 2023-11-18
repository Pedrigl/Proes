using ProesBack.Domain.Entities;

namespace ProesBack.Interfaces
{
    public interface IUserViewModelService
    {
        User GetUserByLoginId(int loginId);

        User GetByUserId(int id);

        void UpdateUser(User user);

        void DeleteUser(int id);

        void InsertUser(User user);

        string UploadPicture(IFormFile picture);
    }
}
