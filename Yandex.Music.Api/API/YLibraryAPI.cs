using System.Net;
using System.Threading.Tasks;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests.Library;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api.API
{
    public class YLibraryAPI
    {
        #region Поля

        private readonly YandexMusicApi api;

        #endregion Поля

        #region Основные функции

        public async Task<YLibraryHistoryResponse> GetHistoryAsync(YAuthStorage storage)
        {
            var request =
                new YGetLibraryHistoryRequest(storage.Context).Create(storage.User.Login, storage.User.Lang, storage.User.Uid);

            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await api.GetDataFromResponseAsync<YLibraryHistoryResponse>(storage.Context, response);
            }
        }

        public YLibraryHistoryResponse GetHistory(YAuthStorage storage)
        {
            return GetHistoryAsync(storage).GetAwaiter().GetResult();
        }

        public async Task<YLibraryPlaylistResponse> GetAsync(YAuthStorage storage)
        {
            var request =
                new YGetLibraryPlaylistRequest(storage.Context).Create(storage.User.Login, storage.User.Lang, storage.User.Uid);

            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await api.GetDataFromResponseAsync<YLibraryPlaylistResponse>(storage.Context, response);
            }
        }

        public YLibraryPlaylistResponse Get(YAuthStorage storage)
        {
            return GetAsync(storage).GetAwaiter().GetResult();
        }

        public YLibraryAPI(YandexMusicApi yandexApi)
        {
            api = yandexApi;
        }

        #endregion Основные функции
    }
}