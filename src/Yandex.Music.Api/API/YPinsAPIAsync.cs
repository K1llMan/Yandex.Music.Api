using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Pins;
using Yandex.Music.Api.Requests.Pins;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с прикреплёнными объектами
    /// </summary>
    public partial class YPinsAPI : YCommonAPI
    {
        #region Основные функции

        public YPinsAPI(YandexMusicApi yandex): base(yandex)
        {
        }

        /// <summary>
        /// Получение списка прикреплённых объектов
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YResponse<YPins>> GetAsync(AuthStorage storage)
        {
            return new YGetPinsBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();
        }

        #endregion Основные функции
    }
}