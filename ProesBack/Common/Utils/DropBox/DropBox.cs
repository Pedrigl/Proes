using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Dropbox.Api;

namespace ProesBack.Common.Utils.DropBox
{
    public class DropBox
    {
        private HttpClient _httpClient;
        private DropboxClient _dropboxClient;
        private readonly string _token = "sl.BoAUIVtfu4ya0YuzCx7BZ2o5ALBzNPV3T8beABOMD9nAhPKoxImGLmlFs907Islwk0LwJGk2X-SoNih6_LEqNbb_N_qoocLREyfRWLZFC8GDiv8LumSqp3sJ3iUcufxJiZQ5pFP4UmbVrBj_XkRnpro";
        private readonly string _inicialPath = "/ProesCloud/";
        private readonly string _appKey = "bf3d4rx4v7h2dhp";
        private readonly string _appSecret = "udr59gfypsgyx1t";

        public DropBox()
        {
            _dropboxClient = new DropboxClient(_token);
        }
        public HttpClient GetAuthorizedHttpClient()
        {
                            
                _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                
            return _httpClient;
        }
        

        public async void GetFileFromDropBox(string filePath)
        {
            //var folders= await _dropboxClient.Files.ListFolderAsync("");
            var download = await _dropboxClient.Files.DownloadAsync(filePath);

            var file = await download.GetContentAsStreamAsync();

            using (var fileStream = new FileStream($"C:\\Users\\Pedro\\pedro.jpg",FileMode.Create,FileAccess.ReadWrite))
            {
                file.CopyTo(fileStream);
            }
            
        }

    }
}
