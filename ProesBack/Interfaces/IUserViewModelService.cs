using ProesBack.Domain.Entities;

namespace ProesBack.Interfaces
{
    public interface IUserViewModelService
    {
        User GetUserByLoginId(long loginId);

        User GetByUserId(long id);

        void UpdateUser(User user);

        void DeleteUser(long id);

        void InsertUser(User user);

        string UploadPicture(IFormFile picture);
    }
}
