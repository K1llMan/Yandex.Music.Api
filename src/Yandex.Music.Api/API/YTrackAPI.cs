using System;
using System.Collections.Generic;
using System.IO;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с треками
    /// </summary>
    public partial class YTrackAPI : YCommonAPI
    {
        #region Основные функции

        /// <summary>
        /// Получение треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackId">Идентификатор трека</param>
        /// <returns></returns>
        public YResponse<List<YTrack>> Get(AuthStorage storage, string trackId)
        {
            return GetAsync(storage, trackId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackIds">Идентификаторы треков</param>
        /// <returns></returns>
        public YResponse<List<YTrack>> Get(AuthStorage storage, IEnumerable<string> trackIds)
        {
            return GetAsync(storage, trackIds).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение метаданных для загрузки
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентифактор трека:идентификатор альбома}</param>
        /// <param name="direct">Должен ли ответ содержать прямую ссылку на загрузку</param>
        /// <returns></returns>
        public YResponse<List<YTrackDownloadInfo>> GetMetadataForDownload(AuthStorage storage, string trackKey, bool direct = false)
        {
            return GetMetadataForDownloadAsync(storage, trackKey, direct).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение метаданных для загрузки
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <param name="direct">Должен ли ответ содержать прямую ссылку на загрузку</param>
        /// <returns></returns>
        public YResponse<List<YTrackDownloadInfo>> GetMetadataForDownload(AuthStorage storage, YTrack track, bool direct = false)
        {
            return GetMetadataForDownloadAsync(storage, track.GetKey().ToString(), direct).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение информации для формирования ссылки для загрузки
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="metadataInfo">Метаданные для загрузки</param>
        /// <returns></returns>
        public YStorageDownloadFile GetDownloadFileInfo(AuthStorage storage, YTrackDownloadInfo metadataInfo)
        {
            return GetDownloadFileInfoAsync(storage, metadataInfo).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение ссылки для загрузки
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентификатор трека:идентификатор альбома}</param>
        /// <returns></returns>
        public string GetFileLink(AuthStorage storage, string trackKey)
        {
            return GetFileLinkAsync(storage, trackKey).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение ссылки для загрузки
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public string GetFileLink(AuthStorage storage, YTrack track)
        {
            return GetFileLinkAsync(storage, track.GetKey().ToString()).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Отправка текущего состояния прослушиваемого трека
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <param name="from">Наименования клиента, с которого происходит прослушивание</param>
        /// <param name="fromCache">Проигрывается ли трек с кеша</param>
        /// <param name="playId">Уникальный идентификатор проигрывания</param>
        /// <param name="playlistId">Уникальный идентификатор плейлиста, если таковой прослушивается</param>
        /// <param name="totalPlayedSeconds">Сколько было всего воспроизведено трека в секундах</param>
        /// <param name="endPositionSeconds">Окончательное значение воспроизведенных секунд</param>
        /// </summary>
        /// <returns></returns>
        public string SendPlayTrackInfo(AuthStorage storage, YTrack track, string from, bool fromCache = false, string playId = "", string playlistId = "", double totalPlayedSeconds = 0, double endPositionSeconds = 0)
        {
            if (string.IsNullOrWhiteSpace(playId))
                playId = $"{new Random(1000)}-{new Random(1000)}-{new Random(1000)}";

            return SendPlayTrackInfoAsync(storage, track, from, fromCache, playId, playlistId, totalPlayedSeconds, endPositionSeconds).GetAwaiter().GetResult();
        }

        #region GetSupplement

        /// <summary>
        /// Получение дополнительной информации для трека
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackId">Идентификатор трека</param>
        /// <returns></returns>
        public YResponse<YTrackSupplement> GetSupplement(AuthStorage storage, string trackId)
        {
            return GetSupplementAsync(storage, trackId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение дополнительной информации для трека
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public YResponse<YTrackSupplement> GetSupplement(AuthStorage storage, YTrack track)
        {
            return GetSupplementAsync(storage, track).GetAwaiter().GetResult();
        }

        #endregion GetSupplement

        #region GetSimilar

        /// <summary>
        /// Получение похожих треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackId">Идентификатор трека</param>
        /// <returns></returns>
        public YResponse<YTrackSimilar> GetSimilar(AuthStorage storage, string trackId)
        {
            return GetSimilarAsync(storage, trackId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение похожих треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public YResponse<YTrackSimilar> GetSimilar(AuthStorage storage, YTrack track)
        {
            return GetSimilarAsync(storage, track).GetAwaiter().GetResult();
        }

        #endregion GetSimilar

        #region Получение данных трека

        #region В файл

        /// <summary>
        /// Выгрузка в файл
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентификатор трека:идентификатор альбома}</param>
        /// <param name="filePath">Путь для файла</param>
        public void ExtractToFile(AuthStorage storage, string trackKey, string filePath)
        {
            ExtractToFileAsync(storage, trackKey, filePath).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Выгрузка в файл
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <param name="filePath">Путь для файла</param>
        public void ExtractToFile(AuthStorage storage, YTrack track, string filePath)
        {
            ExtractToFile(storage, track.GetKey().ToString(), filePath);
        }

        #endregion В файл

        #region В массив байт

        /// <summary>
        /// Получение двоичного массива данных
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентификатор трека:идентификатор альбома}</param>
        /// <returns></returns>
        public byte[] ExtractData(AuthStorage storage, string trackKey)
        {
            return ExtractDataAsync(storage, trackKey).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение двоичного массива данных
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public byte[] ExtractData(AuthStorage storage, YTrack track)
        {
            return ExtractData(storage, track.GetKey().ToString());
        }

        #endregion В массив байт

        #region В поток

        /// <summary>
        /// Получение потока данных
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентификатор трека:идентификатор альбома}</param>
        /// <returns></returns>
        public Stream ExtractStream(AuthStorage storage, string trackKey)
        {
            return ExtractStreamAsync(storage, trackKey).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение потока данных
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public Stream ExtractStream(AuthStorage storage, YTrack track)
        {
            return ExtractStreamAsync(storage, track.GetKey().ToString()).GetAwaiter().GetResult();
        }

        #endregion В поток

        #endregion Получение данных трека

        #endregion Основные функции
    }
}