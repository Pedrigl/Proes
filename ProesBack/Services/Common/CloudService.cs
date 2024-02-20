
using System.Net.Http;

namespace ProesBack.Services.Common
{
    public class CloudService
    {
        private HttpClient httpClient
        {
            get => new HttpClient();
        }

        public async Task<string> UploadPicture(string url, string pictureType, Stream picture)
        {
            httpClient.DefaultRequestHeaders.Add("Content-Type", pictureType);
            var request = await httpClient.PostAsync("upload/drive/v3/files?uploadType=media", new StreamContent(picture));
        }   
        //TODO: CONTINUE GOOGLE DRIVE INTEGRATION
        public static async Task<string> GetAccessToken()
        {
            httpClient.PostAsync();
        }
    }
}
