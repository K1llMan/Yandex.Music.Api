using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Requests.Album;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с исполнителями
    /// </summary>
    public class YArtistAPI
    {
        #region Основные функции

        /// <summary>
        /// Получение исполнителя
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artistId">Идентификатор</param> 
        /// <returns></returns>
        public async Task<YResponse<YArtist>> GetAsync(AuthStorage storage, string artistId)
        {
            return await new YGetArtistRequest(storage)
                .Create(artistId)
                .GetResponseAsync<YResponse<YArtist>>();
        }

        /// <summary>
        /// Получение исполнителя
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artistId">Идентификатор</param>
        public YResponse<YArtist> Get(AuthStorage storage, string artistId)
        {
            return GetAsync(storage, artistId).GetAwaiter().GetResult();
        }

        #endregion Основные функции
    }
}