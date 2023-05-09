using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Feed;
using Yandex.Music.Api.Models.Landing;
using Yandex.Music.Api.Requests.Feed;
using Yandex.Music.Api.Requests.Landing;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с главной страницей
    /// </summary>
    public partial class YLandingAPI: YCommonAPI
    {
        #region Основные функции

        public YLandingAPI(YandexMusicApi yandex) : base(yandex)
        {
        }

        /// <summary>
        /// Получение персональных списков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="blocks">Типы запрашиваемых блоков</param>
        /// <returns></returns>
        public Task<YResponse<YLanding>> GetAsync(AuthStorage storage, params YLandingBlockType[] blocks)
        {
            if (blocks == null)
                return null;

            return new YGetLandingBuilder(api, storage)
                .Build(blocks)
                .GetResponseAsync();
        }

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

        #endregion Основные функции
    }
}