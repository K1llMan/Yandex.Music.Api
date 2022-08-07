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
        public async Task<YResponse<YArtistBriefInfo>> GetAsync(AuthStorage storage, string artistId)
        {
            return await new YGetArtistRequest(api, storage)
                .Create(artistId)
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

        #endregion Основные функции
    }
}