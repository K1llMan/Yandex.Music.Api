using System.Net.Http;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Common.Providers;

namespace Yandex.Music.Api.Requests.Common
{
    internal class YRequest<T>
    {
        #region Поля

        private HttpRequestMessage msg;
        private IRequestProvider provider;

        protected YandexMusicApi api;

        #endregion Поля

        #region Основные функции

        public YRequest(HttpRequestMessage message, YandexMusicApi yandex, AuthStorage auth)
        {
            msg = message;
            api = yandex;
            provider = auth.Provider;
        }

        public async Task<T> GetResponseAsync()
        {
            if (msg == null)
                return default;

            HttpResponseMessage response = await provider.GetWebResponseAsync(msg);

            if (typeof(T) == typeof(HttpResponseMessage))
                return (T)(object)response;

            try
            {
                return await provider.GetDataFromResponseAsync<T>(api, response);
            }
            finally
            {
                response.Dispose();
            }
        }

        #endregion Основные функции
    }
}
