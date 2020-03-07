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
            return await new YGetLibraryHistoryRequest(storage)
                .Create()
                .GetResponseAsync<YLibraryHistoryResponse>();
        }

        public YLibraryHistoryResponse GetHistory(YAuthStorage storage)
        {
            return GetHistoryAsync(storage).GetAwaiter().GetResult();
        }

        public async Task<YLibraryPlaylistResponse> GetAsync(YAuthStorage storage)
        {
            return await new YGetLibraryPlaylistRequest(storage)
                .Create()
                .GetResponseAsync<YLibraryPlaylistResponse>();
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