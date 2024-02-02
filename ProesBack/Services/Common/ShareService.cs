using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Sas;
using Dropbox.Api.TeamLog;
using Microsoft.AspNetCore.Mvc;
using ProesBack.Interfaces.Common;
namespace ProesBack.Services.Common
{
    public class ShareService : IShareService
    {
        private readonly ShareServiceClient _shareServiceClient;
        private readonly ShareClient _shareClient;

        public ShareService(string connectionString, string shareName)
        {
            _shareServiceClient = new ShareServiceClient(connectionString);
            _shareClient = _shareServiceClient.GetShareClient(shareName);
        }

        public ShareFileUploadInfo UploadProfilePicture(string fileName, Stream stream)
        {
            ShareDirectoryClient directoryClient = _shareClient.GetDirectoryClient("ProfilePictures");

            ShareFileClient fileClient = directoryClient.GetFileClient(fileName);
            stream.Position = 0;
            var fileInfo = fileClient.Create(stream.Length);
            var fileUploadInfo = fileClient.Upload(stream);

            return fileUploadInfo;
        }

        public string GetAuthorizedLinkToProfilePicture(string fileName)
        {
            ShareDirectoryClient directoryClient = _shareClient.GetDirectoryClient("ProfilePictures");
            ShareFileClient fileClient = directoryClient.GetFileClient(fileName);
            var canGenerateUri = fileClient.CanGenerateSasUri;

            return fileClient.GenerateSasUri(ShareFileSasPermissions.Read, DateTimeOffset.UtcNow.AddHours(1)).ToString();
        }
    }
}
