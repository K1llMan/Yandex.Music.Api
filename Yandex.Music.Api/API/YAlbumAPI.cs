using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests.Album;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api.API
{
    public class YAlbumAPI
    {
        #region Основные функции

        public async Task<YAlbumResponse> GetAsync(YAuthStorage storage, string albumId)
        {
            return await new YGetAlbumRequest(storage)
                .Create(albumId)
                .GetResponseAsync<YAlbumResponse>();
        }

        public YAlbumResponse Get(YAuthStorage storage, string albumId)
        {
            return GetAsync(storage, albumId).GetAwaiter().GetResult();
        }

        #endregion Основные функции
    }
}