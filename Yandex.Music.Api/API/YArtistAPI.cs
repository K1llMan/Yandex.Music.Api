using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests.Album;
using Yandex.Music.Api.Responses;

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
        public async Task<YArtistResponse> GetAsync(YAuthStorage storage, string artistId)
        {
            return await new YGetArtistRequest(storage)
                .Create(artistId)
                .GetResponseAsync<YArtistResponse>();
        }

        /// <summary>
        /// Получение исполнителя
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artistId">Идентификатор</param>
        public YArtistResponse Get(YAuthStorage storage, string artistId)
        {
            return GetAsync(storage, artistId).GetAwaiter().GetResult();
        }

        #endregion Основные функции
    }
}