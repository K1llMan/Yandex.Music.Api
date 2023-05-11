using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Feed;
using Yandex.Music.Api.Models.Landing;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с главной страницей
    /// </summary>
    public partial class YLandingAPI
    {
        #region Основные функции

        /// <summary>
        /// Получение персональных списков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="blocks">Типы запрашиваемых блоков</param>
        /// <returns></returns>
        public YResponse<YLanding> Get(AuthStorage storage, params YLandingBlockType[] blocks)
        {
            return GetAsync(storage, blocks).GetAwaiter().GetResult();
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

        #endregion Основные функции
    }
}