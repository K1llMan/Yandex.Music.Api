using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests.Album;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с альбомами
    /// </summary>
    public class YAlbumAPI
    {
        #region Основные функции

        /// <summary>
        /// Получение альбома
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="albumId">Идентификатор</param> 
        /// <returns></returns>
        public async Task<YAlbumResponse> GetAsync(YAuthStorage storage, string albumId)
        {
            return await new YGetAlbumRequest(storage)
                .Create(albumId)
                .GetResponseAsync<YAlbumResponse>();
        }

        /// <summary>
        /// Получение альбома
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="albumId">Идентификатор</param>
        public YAlbumResponse Get(YAuthStorage storage, string albumId)
        {
            return GetAsync(storage, albumId).GetAwaiter().GetResult();
        }

        #endregion Основные функции
    }
}