using System.Collections.Generic;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с исполнителями
    /// </summary>
    public partial class YArtistAPI
    {
        #region Основные функции

        /// <summary>
        /// Получение исполнителя
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artistId">Идентификатор</param>
        public YResponse<YArtistBriefInfo> Get(AuthStorage storage, string artistId)
        {
            return GetAsync(storage, artistId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение исполнителя
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artistIds">Идентификаторы</param> 
        public YResponse<List<YArtist>> Get(AuthStorage storage, IEnumerable<string> artistIds)
        {
            return GetAsync(storage, artistIds).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение треков исполнителя с пагинацией
        /// <remarks>
        /// Треки поставляются по <paramref name="pageSize"/> штук на страницу,
        /// для получения всех треков необходимо использовать метод <see cref="GetAllTracks"/> 
        /// </remarks>
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artistId">Идентификатор исполнителя</param>
        /// <param name="page">Страница ответов</param>
        /// <param name="pageSize">Количество треков на странице ответов</param>
        public YResponse<YTracksPage> GetTracks(AuthStorage storage, string artistId, int page = 0,
            int pageSize = 20)
        {
            return GetTracksAsync(storage, artistId, page, pageSize).GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Получение всех треков исполнителя
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artistId">Идентификатор исполнителя</param>
        public YResponse<YTracksPage> GetAllTracks(AuthStorage storage, string artistId)
        {
            return GetAllTracksAsync(storage, artistId).GetAwaiter().GetResult();
        }

        #endregion Основные функции
    }
}