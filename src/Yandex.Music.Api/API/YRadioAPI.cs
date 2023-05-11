using System.Collections.Generic;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Radio;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с радио
    /// </summary>
    public partial class YRadioAPI
    {
        #region Основные функции

        /// <summary>
        /// Получение списка рекомендованных радиостанций радиостанций
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YResponse<YStationsDashboard> GetStationsDashboard(AuthStorage storage)
        {
            return GetStationsDashboardAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение списка радиостанций
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YResponse<List<YStation>> GetStations(AuthStorage storage)
        {
            return GetStationsAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение информации о радиостанции
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="type">Тип</param>
        /// <param name="tag">Тэг</param>
        /// <returns></returns>
        public YResponse<List<YStation>> GetStation(AuthStorage storage, string type, string tag)
        {
            return GetStationAsync(storage, type, tag).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение информации о радиостанции
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="id">Идентификатор станции</param>
        /// <returns></returns>
        public YResponse<List<YStation>> GetStation(AuthStorage storage, YStationId id)
        {
            return GetStationAsync(storage, id.Type, id.Tag).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение последовательности треков радиостанции
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="station">Радиостанция</param>
        /// <param name="prevTrackId">Идентификатор предыдущего трека</param>
        /// <returns></returns>
        public YResponse<YStationSequence> GetStationTracks(AuthStorage storage, YStation station, string prevTrackId = "")
        {
            return GetStationTracksAsync(storage, station, prevTrackId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Установка настроек подбора треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="station">Радиостанция</param>
        /// <param name="settings">Настройки</param>
        /// <returns></returns>
        public YResponse<string> SetStationSettings2(AuthStorage storage, YStation station, YStationSettings2 settings)
        {
            return SetStationSettings2Async(storage, station, settings).GetAwaiter().GetResult();
        }

        #endregion Основные функции
    }
}