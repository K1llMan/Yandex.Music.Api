using System.Net;
using System.Threading.Tasks;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests.Album;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api.API
{
    public class YAlbumAPI
    {
        #region Поля

        private readonly YandexMusicApi api;

        #endregion Поля

        #region Основные функции

        public async Task<YAlbumResponse> GetAsync(YAuthStorage storage, string albumId)
        {
            var request = new YGetAlbumRequest(storage.Context).Create(albumId, storage.User.Lang);

            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await api.GetDataFromResponseAsync<YAlbumResponse>(storage.Context, response);
            }
        }

        public YAlbumResponse Get(YAuthStorage storage, string albumId)
        {
            return GetAsync(storage, albumId).GetAwaiter().GetResult();
        }

        public YAlbumAPI(YandexMusicApi yandexApi)
        {
            api = yandexApi;
        }

        #endregion Основные функции
    }
}