using System.Collections.Generic;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Radio;
using Yandex.Music.Api.Requests.Radio;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с радио
    /// </summary>
    public partial class YRadioAPI : YCommonAPI
    {
        #region Основные функции

        public YRadioAPI(YandexMusicApi yandex): base(yandex)
        {
        }

        /// <summary>
        /// Получение списка рекомендованных радиостанций
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YResponse<YStationsDashboard>> GetStationsDashboardAsync(AuthStorage storage)
        {
            return new YGetStationsDashboardBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();
        }

        /// <summary>
        /// Получение списка радиостанций
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YResponse<List<YStation>>> GetStationsAsync(AuthStorage storage)
        {
            return new YGetStationsBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();
        }

        /// <summary>
        /// Получение информации о радиостанции
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="type">Тип</param>
        /// <param name="tag">Тэг</param>
        /// <returns></returns>
        public Task<YResponse<List<YStation>>> GetStationAsync(AuthStorage storage, string type, string tag)
        {
            return new YGetStationBuilder(api, storage)
                .Build((type, tag))
                .GetResponseAsync();
        }

        /// <summary>
        /// Получение информации о радиостанции
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="id">Идентификатор станции</param>
        /// <returns></returns>
        public Task<YResponse<List<YStation>>> GetStationAsync(AuthStorage storage, YStationId id)
        {
            return GetStationAsync(storage, id.Type, id.Tag);
        }

        /// <summary>
        /// Получение последовательности треков радиостанции
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="station">Радиостанция</param>
        /// <param name="prevTrackId">Идентификатор предыдущего трека</param>
        /// <returns></returns>
        public Task<YResponse<YStationSequence>> GetStationTracksAsync(AuthStorage storage, YStation station, string prevTrackId = "")
        {
            return new YGetStationTracksBuilder(api, storage)
                .Build((station.Station, prevTrackId))
                .GetResponseAsync();
        }

        /// <summary>
        /// Установка настроек подбора треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="station">Радиостанция</param>
        /// <param name="settings">Настройки</param>
        /// <returns></returns>
        public Task<YResponse<string>> SetStationSettings2Async(AuthStorage storage, YStation station, YStationSettings2 settings)
        {
            return new YSetSettings2Builder(api, storage)
                .Build((station.Station, settings))
                .GetResponseAsync();
        }

        #endregion Основные функции
    }
}