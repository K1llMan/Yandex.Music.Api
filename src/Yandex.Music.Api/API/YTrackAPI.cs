using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Track;
using Yandex.Music.Api.Requests.Track;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с треками
    /// </summary>
    public class YTrackAPI : YCommonAPI
    {
        #region Вспомогательные функции

        private string BuildLinkForDownload(YTrackDownloadInfo mainDownloadResponse, YStorageDownloadFile storageDownload)
        {
            string path = storageDownload.Path;
            string host = storageDownload.Host;
            string ts = storageDownload.Ts;
            string s = storageDownload.S;
            string codec = mainDownloadResponse.Codec;

            string secret = $"XGRlBW9FXlekgbPrRHuSiA{path.Substring(1, path.Length - 1)}{s}";
            MD5 md5 = MD5.Create();
            byte[] md5Hash = md5.ComputeHash(Encoding.UTF8.GetBytes(secret));
            HMACSHA1 hmacsha1 = new();
            byte[] hmasha1Hash = hmacsha1.ComputeHash(md5Hash);
            string sign = BitConverter.ToString(hmasha1Hash).Replace("-", "").ToLower();

            string link = $"https://{host}/get-{codec}/{sign}/{ts}{path}";

            return link;
        }

        #endregion Вспомогательные функции

        #region Основные функции

        public YTrackAPI(YandexMusicApi yandex): base(yandex)
        {
        }

        /// <summary>
        /// Получение треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackId">Идентификатор трека</param>
        /// <returns></returns>
        public Task<YResponse<List<YTrack>>> GetAsync(AuthStorage storage, string trackId)
        {
            return new YGetTracksBuilder(api, storage)
                .Build(new[] { trackId })
                .GetResponseAsync();
        }

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
        public Task<YResponse<List<YTrack>>> GetAsync(AuthStorage storage, IEnumerable<string> trackIds)
        {
            return new YGetTracksBuilder(api, storage)
                .Build(trackIds)
                .GetResponseAsync();
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
        public Task<YResponse<List<YTrackDownloadInfo>>> GetMetadataForDownloadAsync(AuthStorage storage, string trackKey, bool direct)
        {
            return new YTrackDownloadInfoBuilder(api, storage)
                .Build((trackKey, direct))
                .GetResponseAsync();
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
        public Task<YResponse<List<YTrackDownloadInfo>>> GetMetadataForDownloadAsync(AuthStorage storage, YTrack track, bool direct = false)
        {
            return GetMetadataForDownloadAsync(storage, track.GetKey().ToString(), direct);
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
        public Task<YStorageDownloadFile> GetDownloadFileInfoAsync(AuthStorage storage, YTrackDownloadInfo metadataInfo)
        {
            return new YStorageDownloadFileBuilder(api, storage)
                .Build(metadataInfo.DownloadInfoUrl)
                .GetResponseAsync();
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
            YTrackDownloadInfo mainDownloadResponse = GetMetadataForDownload(storage, trackKey)
                .Result
                .OrderByDescending(i => i.BitrateInKbps)
                .First(m => m.Codec == "mp3");
            YStorageDownloadFile storageDownloadResponse = GetDownloadFileInfo(storage, mainDownloadResponse);

            return BuildLinkForDownload(mainDownloadResponse, storageDownloadResponse);
        }

        /// <summary>
        /// Получение ссылки для загрузки
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public string GetFileLink(AuthStorage storage, YTrack track)
        {
            return GetFileLink(storage, track.GetKey().ToString());
        }

        #region GetSupplement

        /// <summary>
        /// Получение дополнительной информации для трека
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackId">Идентификатор трека</param>
        /// <returns></returns>
        public Task<YResponse<YTrackSupplement>> GetSupplementAsync(AuthStorage storage, string trackId)
        {
            return new YGetTrackSupplementBuilder(api, storage)
                .Build(trackId)
                .GetResponseAsync();
        }

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
        public Task<YResponse<YTrackSupplement>> GetSupplementAsync(AuthStorage storage, YTrack track)
        {
            return new YGetTrackSupplementBuilder(api, storage)
                .Build(track.GetKey().ToString())
                .GetResponseAsync();
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
        public Task<YResponse<YTrackSimilar>> GetSimilarAsync(AuthStorage storage, string trackId)
        {
            return new YGetTrackSimilarBuilder(api, storage)
                .Build(trackId)
                .GetResponseAsync();
        }

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
        public Task<YResponse<YTrackSimilar>> GetSimilarAsync(AuthStorage storage, YTrack track)
        {
            return new YGetTrackSimilarBuilder(api, storage)
                .Build(track.GetKey().ToString())
                .GetResponseAsync();
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

        /// <summary>
        /// Выгрузка в файл
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентификатор трека:идентификатор альбома}</param>
        /// <param name="filePath">Путь для файла</param>
        public void ExtractToFile(AuthStorage storage, string trackKey, string filePath)
        {
            string fileLink = GetFileLink(storage, trackKey);

            try
            {
                using WebClient client = new();
                client.DownloadFile(fileLink, filePath);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
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

        /// <summary>
        /// Получение двоичного массива данных
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентификатор трека:идентификатор альбома}</param>
        /// <returns></returns>
        public byte[] ExtractData(AuthStorage storage, string trackKey)
        {
            string fileLink = GetFileLink(storage, trackKey);

            byte[] bytes = default;

            try
            {
                using WebClient client = new();
                bytes = client.DownloadData(fileLink);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }

            return bytes;
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

        #endregion Получение данных трека

        #endregion Основные функции
    }
}