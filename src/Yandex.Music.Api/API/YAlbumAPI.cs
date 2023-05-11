using System.Collections.Generic;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Album;
using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с альбомами
    /// </summary>
    public partial class YAlbumAPI
    {
        #region Основные функции

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
        public YResponse<List<YAlbum>> Get(AuthStorage storage, IEnumerable<string> albumIds)
        {
            return GetAsync(storage, albumIds).GetAwaiter().GetResult();
        }

        #endregion Основные функции
    }
}