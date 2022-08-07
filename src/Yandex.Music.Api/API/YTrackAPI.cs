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

        private string BuildLinkForDownload(YTrackDownloadInfo mainDownloadResponse,
            YStorageDownloadFile storageDownload)
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
        /// Получение трека
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackId">Идентификатор трека</param>
        /// <returns></returns>
        public async Task<YResponse<List<YTrack>>> GetAsync(AuthStorage storage, string trackId)
        {
            return await new YGetTrackRequest(api, storage)
                .Create(trackId)
                .GetResponseAsync();
        }

        /// <summary>
        /// Получение трека
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackId">Идентификатор трека</param>
        /// <returns></returns>
        public YResponse<List<YTrack>> Get(AuthStorage storage, string trackId)
        {
            return GetAsync(storage, trackId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение метаданных для загрузки
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентифактор трека:идентификатор альбома}</param>
        /// <param name="direct">Должен ли ответ содержать прямую ссылку на загрузку</param>
        /// <returns></returns>
        public async Task<YResponse<List<YTrackDownloadInfo>>> GetMetadataForDownloadAsync(AuthStorage storage, string trackKey, bool direct)
        {
            return await new YTrackDownloadInfoRequest(api, storage)
                .Create(trackKey, direct)
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
        public async Task<YResponse<List<YTrackDownloadInfo>>> GetMetadataForDownloadAsync(AuthStorage storage, YTrack track, bool direct = false)
        {
            return await GetMetadataForDownloadAsync(storage, track.GetKey().ToString(), direct);
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
        public async Task<YStorageDownloadFile> GetDownloadFileInfoAsync(AuthStorage storage, YTrackDownloadInfo metadataInfo)
        {
            return await new YStorageDownloadFileRequest(api, storage)
                .Create(metadataInfo.DownloadInfoUrl)
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