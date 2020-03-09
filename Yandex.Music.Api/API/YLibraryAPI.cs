using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests.Library;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с библиотекой
    /// </summary>
    public class YLibraryAPI
    {
        #region Основные функции

        /// <summary>
        /// Получение истории
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<YLibraryHistoryResponse> GetHistoryAsync(YAuthStorage storage)
        {
            return await new YGetLibraryHistoryRequest(storage)
                .Create()
                .GetResponseAsync<YLibraryHistoryResponse>();
        }

        /// <summary>
        /// Получение истории
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YLibraryHistoryResponse GetHistory(YAuthStorage storage)
        {
            return GetHistoryAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение библиотеки
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<YLibraryPlaylistResponse> GetAsync(YAuthStorage storage)
        {
            return await new YGetLibraryPlaylistRequest(storage)
                .Create()
                .GetResponseAsync<YLibraryPlaylistResponse>();
        }

        /// <summary>
        /// Получение библиотеки
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YLibraryPlaylistResponse Get(YAuthStorage storage)
        {
            return GetAsync(storage).GetAwaiter().GetResult();
        }

        #endregion Основные функции
    }
}