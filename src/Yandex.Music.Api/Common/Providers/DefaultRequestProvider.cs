using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Common.Providers
{
    /// <summary>
    /// Стандартный провайдер запросов
    /// </summary>
    public class DefaultRequestProvider: CommonRequestProvider
    {
        #region Вспомогательные функции

        private static Exception ProcessException(Exception ex)
        {
            if (ex is not WebException webException) 
                return ex;

            if (webException.Response is null)
                return ex;

            Stream s = webException.Response.GetResponseStream();
            if (s is null)
                return ex;

            using StreamReader sr = new(s);
            string result = sr.ReadToEnd();
                
            YErrorResponse exception = JsonConvert.DeserializeObject<YErrorResponse>(result);

            return exception ?? ex;
        }

        #endregion Вспомогательные функции

        #region Основные функции

        public DefaultRequestProvider(AuthStorage authStorage): base(authStorage)
        {
        }

        #endregion Основные функции

        #region IRequestProvider

        public override Task<HttpResponseMessage> GetWebResponseAsync(HttpRequestMessage message)
        {
            try
            {
                HttpMessageHandler httpClientHandler =
#if NET7_0_OR_GREATER
                    new SocketsHttpHandler()
#else
                    new HttpClientHandler()
#endif
                    {
                        Proxy = storage.Context.WebProxy,
                        AutomaticDecompression = DecompressionMethods.GZip,
                        UseCookies = true,
                        CookieContainer = storage.Context.Cookies,
                    };

                HttpClient client =
#if NET7_0_OR_GREATER
                    new(
#else
                    HttpClientFactory.Create(
#endif
                        httpClientHandler
                    );

                return client.SendAsync(message);
            }
            catch (Exception ex)
            {
                throw ProcessException(ex);
            }
        }

        #endregion IRequestProvider
    }
}
