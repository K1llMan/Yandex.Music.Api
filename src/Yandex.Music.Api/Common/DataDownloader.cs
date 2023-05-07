using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Yandex.Music.Api.Common
{
    /// <summary>
    /// Загрузчик файлов по ссылке
    /// </summary>
    public class DataDownloader
    {
        private AuthStorage authStorage;

        private Task<HttpContent> GetResponse(string url)
        {
            HttpRequestMessage message = new(new HttpMethod(WebRequestMethods.Http.Get), url);

            return authStorage.Provider.GetWebResponseAsync(message)
                .ContinueWith(response => response.Result.Content);
        }

        public Task<Stream> AsStream(string url)
        {
            return GetResponse(url)
                .ContinueWith(r => r.Result.ReadAsStreamAsync())
                .ContinueWith(s => s.Result.Result);
        }

        public Task<byte[]> AsBytes(string url)
        {
            return GetResponse(url)
                .ContinueWith(r => r.Result.ReadAsByteArrayAsync())
                .ContinueWith(s => s.Result.Result);
        }

        public async Task ToFile(string url, string fileName)
        {
            using Stream stream = await AsStream(url);
            using FileStream fs = File.Create(fileName);
            await stream.CopyToAsync(fs);
        }

        public DataDownloader(AuthStorage storage)
        {
            authStorage = storage;
        }
    }
}