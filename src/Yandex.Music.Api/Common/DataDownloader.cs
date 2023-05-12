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

        private async Task<HttpContent> GetResponseContent(string url)
        {
            HttpRequestMessage message = new(new HttpMethod(WebRequestMethods.Http.Get), url);

            HttpResponseMessage response = await authStorage.Provider.GetWebResponseAsync(message);
            return response.Content;
        }

        public async Task<Stream> AsStream(string url)
        {
            HttpContent content = await GetResponseContent(url);
            return await content.ReadAsStreamAsync();
        }

        public async Task<byte[]> AsBytes(string url)
        {
            HttpContent content = await GetResponseContent(url);
            return await content.ReadAsByteArrayAsync();
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