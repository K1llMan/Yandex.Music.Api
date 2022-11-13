using System.Collections.Generic;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Requests.Artist;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с исполнителями
    /// </summary>
    public class YArtistAPI : YCommonAPI
    {
        #region Основные функции

        public YArtistAPI(YandexMusicApi yandex): base(yandex)
        {
        }

        /// <summary>
        /// Получение исполнителя
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artistId">Идентификатор</param> 
        /// <returns></returns>
        public Task<YResponse<YArtistBriefInfo>> GetAsync(AuthStorage storage, string artistId)
        {
            return new YGetArtistBuilder(api, storage)
                .Build(artistId)
                .GetResponseAsync();
        }

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
        /// Получение исполнителей
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artistIds">Идентификаторы</param> 
        /// <returns></returns>
        public Task<YResponse<List<YArtist>>> GetAsync(AuthStorage storage, IEnumerable<string> artistIds)
        {
            return new YGetArtistsBuilder(api, storage)
                .Build(artistIds)
                .GetResponseAsync();
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

        #endregion Основные функции
    }
}