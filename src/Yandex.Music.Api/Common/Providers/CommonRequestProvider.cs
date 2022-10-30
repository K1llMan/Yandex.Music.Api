using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Common.Providers
{
    public class CommonRequestProvider: IRequestProvider
    {
        #region Поля

        protected AuthStorage storage;

        #endregion Поля

        #region Основные функции

        public CommonRequestProvider(AuthStorage authStorage)
        {
            storage = authStorage;
        }

        #endregion Основные функции

        #region IRequestProvider

        public virtual Task<HttpResponseMessage> GetWebResponseAsync(HttpRequestMessage message)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetDataFromResponseAsync<T>(YandexMusicApi api, HttpResponseMessage response)
        {
            string result = await response.Content.ReadAsStringAsync();

            JsonSerializerSettings settings = new() {
                Converters = new List<JsonConverter> {
                    new YExecutionContextConverter(api, storage)
                }
            };

            return storage.Debug != null
                ? storage.Debug.Deserialize<T>(response.RequestMessage?.RequestUri?.AbsolutePath, result, settings)
                : JsonConvert.DeserializeObject<T>(result, settings); ;
        }

        #endregion IRequestProvider
    }
}