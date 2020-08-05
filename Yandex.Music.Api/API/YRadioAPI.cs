using System.Collections.Generic;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Radio;
using Yandex.Music.Api.Requests.Track;

namespace Yandex.Music.Api.API
{
    public class YRadioAPI: YCommonAPI
    {
        #region Вспомогательные функции

        #endregion Вспомогательные функции

        #region Основные функции

        public YRadioAPI(YandexMusicApi yandex) :base(yandex)
        {
        }

        /// <summary>
        /// Получение списка рекомендованных радиостанций радиостанций
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<YResponse<YStationsDashboard>> GetStationsDashboardAsync(AuthStorage storage)
        {
            return await new YGetStationsDashboardRequest(api, storage)
                .Create()
                .GetResponseAsync<YResponse<YStationsDashboard>>();
        }

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
        public async Task<YResponse<List<YStation>>> GetStationsAsync(AuthStorage storage)
        {
            return await new YGetStationsRequest(api, storage)
                .Create()
                .GetResponseAsync<YResponse<List<YStation>>>();
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
        public async Task<YResponse<List<YStation>>> GetStationAsync(AuthStorage storage, string type, string tag)
        {
            return await new YGetStationRequest(api, storage)
                .Create(type, tag)
                .GetResponseAsync<YResponse<List<YStation>>>();
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
        public Task<YResponse<List<YStation>>> GetStationAsync(AuthStorage storage, YStationId id)
        {
            return GetStationAsync(storage, id.Type, id.Tag);
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
        /// <returns></returns>
        public async Task<YResponse<YStationSequence>> GetStationTracksAsync(AuthStorage storage, YStation station, string prevTrackId = "")
        {
            return await new YGetStationTracksRequest(api, storage)
                .Create(station.Station, prevTrackId)
                .GetResponseAsync<YResponse<YStationSequence>>();
        }

        /// <summary>
        /// Получение последовательности треков радиостанции
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="station">Радиостанция</param>
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
        public async Task<YResponse<string>> SetStationSettings2Async(AuthStorage storage, YStation station, YStationSettings2 settings)
        {
            return await new YSetSettings2Request(api, storage)
                .Create(station.Station, settings)
                .GetResponseAsync<YResponse<string>>();
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