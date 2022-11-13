using System.Collections.Generic;
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
        public Task<YResponse<YAlbum>> GetAsync(AuthStorage storage, string albumId)
        {
            return new YGetAlbumBuilder(api, storage)
                .Build(albumId)
                .GetResponseAsync();
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

        /// <summary>
        /// Получение альбомов по списку
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="albumIds">Идентификаторы альбомов</param> 
        /// <returns></returns>
        public Task<YResponse<List<YAlbum>>> GetAsync(AuthStorage storage, IEnumerable<string> albumIds)
        {
            return new YGetAlbumsBuilder(api, storage)
                .Build(albumIds)
                .GetResponseAsync();
        }

        /// <summary>
        /// Получение альбомов по списку
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="albumIds">Идентификаторы альбомов</param> 
        /// <returns></returns>
        public YResponse<List<YAlbum>> Get(AuthStorage storage, IEnumerable<string> albumIds)
        {
            return GetAsync(storage, albumIds).GetAwaiter().GetResult();
        }

        #endregion Основные функции
    }
}