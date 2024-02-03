using Azure.Storage.Files.Shares.Models;
using ProesBack.Domain.Entities;
using ProesBack.Domain.Enums;
using ProesBack.ViewModels;

namespace ProesBack.Interfaces
{
    public interface IUserViewModelService
    {
        UserViewModel GetUserByLoginId(long loginId);

        UserViewModel GetByUserId(long id);

        void UpdateUser(UserViewModel user);

        void DeleteUser(long id);

        void InsertUser(UserViewModel user);
        ShareFileUploadInfo UploadPicture(long userId, IFormFile picture);
        string GetLinkToPicture(long userId);
        PictureType[] GetSupportedPictureTypes();
    }
}
