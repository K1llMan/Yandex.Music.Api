using System.Net;
using System.Threading.Tasks;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests.Account;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api.API
{
    public class YAccountsAPI
    {
        #region Поля

        private readonly YandexMusicApi api;

        #endregion Поля

        #region Основные функции

        public async Task<YAccountResponse> GetAsync(YAuthStorage storage)
        {
            var request = new YGetAccountRequest(storage.Context).Create(storage.User.Lang);

            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await api.GetDataFromResponseAsync<YAccountResponse>(storage.Context, response);
            }
        }

        public YAccountResponse Get(YAuthStorage storage)
        {
            return GetAsync(storage).GetAwaiter().GetResult();
        }

        public YAccountsAPI(YandexMusicApi yandexApi)
        {
            api = yandexApi;
        }

        #endregion Основные функции
    }
}