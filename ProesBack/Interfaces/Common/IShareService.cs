using Azure.Storage.Files.Shares.Models;

namespace ProesBack.Interfaces.Common
{
    public interface IShareService
    {
        ShareFileUploadInfo UploadProfilePicture(string fileName, Stream stream);
        string GetAuthorizedLinkToProfilePicture(string fileName);
    }
}
