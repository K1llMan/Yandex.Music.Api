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

            using HttpResponseMessage response = await provider.GetWebResponseAsync(msg);

            return typeof(T) == typeof(HttpResponseMessage)
                ? (T)(object)response
                : await provider.GetDataFromResponseAsync<T>(api, response);
        }

        #endregion Основные функции
    }
}