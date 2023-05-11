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
    public partial class YArtistAPI : YCommonAPI
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
        public Task<YResponse<YArtistBriefInfo>> GetAsync(AuthStorage storage, string artistId)
        {
            return new YGetArtistBuilder(api, storage)
                .Build(artistId)
                .GetResponseAsync();
        }

        /// <summary>
        /// Получение исполнителей
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artistIds">Идентификаторы</param> 
        public Task<YResponse<List<YArtist>>> GetAsync(AuthStorage storage, IEnumerable<string> artistIds)
        {
            return new YGetArtistsBuilder(api, storage)
                .Build(artistIds)
                .GetResponseAsync();
        }

        /// <summary>
        /// Получение треков исполнителя с пагинацией
        /// <remarks>
        /// Треки поставляются по <paramref name="pageSize"/> штук на страницу,
        /// для получения всех треков необходимо использовать метод <see cref="GetAllTracksAsync"/> 
        /// </remarks>
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artistId">Идентификатор исполнителя</param>
        /// <param name="page">Страница ответов</param>
        /// <param name="pageSize">Количество треков на странице ответов</param>
        public Task<YResponse<YTracksPage>> GetTracksAsync(AuthStorage storage, string artistId, int page = 0, int pageSize = 20)
        {
            return new YGetArtistTrackBuilder(api, storage)
                .Build((artistId, page, pageSize))
                .GetResponseAsync();
        }

        /// <summary>
        /// Получение всех треков исполнителя
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artistId">Идентификатор исполнителя</param>
        public async Task<YResponse<YTracksPage>> GetAllTracksAsync(AuthStorage storage, string artistId)
        {
            YResponse<YArtistBriefInfo> response = await GetAsync(storage, artistId);
            return await GetTracksAsync(storage, artistId, pageSize: response.Result.Artist.Counts.Tracks);
        }

        #endregion Основные функции
    }
}