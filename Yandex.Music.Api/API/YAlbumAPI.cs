using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Album;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Requests.Album;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с альбомами
    /// </summary>
    public class YAlbumAPI : YCommonAPI
    {
        #region Основные функции

        public YAlbumAPI(YandexMusicApi yandex): base(yandex)
        {
        }

        /// <summary>
        /// Получение альбома
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="albumId">Идентификатор</param> 
        /// <returns></returns>
        public async Task<YResponse<YAlbum>> GetAsync(AuthStorage storage, string albumId)
        {
            return await new YGetAlbumRequest(api, storage)
                .Create(albumId)
                .GetResponseAsync<YResponse<YAlbum>>();
        }

        /// <summary>
        /// Получение альбома
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="albumId">Идентификатор</param>
        public YResponse<YAlbum> Get(AuthStorage storage, string albumId)
        {
            return GetAsync(storage, albumId).GetAwaiter().GetResult();
        }

        #endregion Основные функции
    }
}