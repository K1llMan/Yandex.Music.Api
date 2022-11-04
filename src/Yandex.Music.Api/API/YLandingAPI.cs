using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Feed;
using Yandex.Music.Api.Requests.Feed;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с главной страницей
    /// </summary>
    public class YLandingAPI: YCommonAPI
    {
        #region Основные функции

        /// <summary>
        /// Получение ленты
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YResponse<YFeed>> GetFeedAsync(AuthStorage storage)
        {
            return new YGetFeedBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();
        }

        /// <summary>
        /// Получение ленты
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YResponse<YFeed> GetFeed(AuthStorage storage)
        {
            return GetFeedAsync(storage).GetAwaiter().GetResult();
        }

        public YLandingAPI(YandexMusicApi yandex) : base(yandex)
        {
        }

        #endregion Основные функции
    }
}