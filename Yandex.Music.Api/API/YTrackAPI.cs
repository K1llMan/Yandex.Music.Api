using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests.Track;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с треками
    /// </summary>
    public class YTrackAPI
    {
        #region Вспомогательные функции

        private string BuildLinkForDownload(YTrackDownloadInfoResponse mainDownloadResponse,
            YStorageDownloadFileResponse storageDownloadResponse)
        {
            var path = storageDownloadResponse.Path;
            var host = storageDownloadResponse.Host;
            var ts = storageDownloadResponse.Ts;
            var s = storageDownloadResponse.S;
            var codec = mainDownloadResponse.Codec;

            var secret = $"XGRlBW9FXlekgbPrRHuSiA{path.Substring(1, path.Length - 1)}{s}";
            var md5 = MD5.Create();
            var md5Hash = md5.ComputeHash(Encoding.UTF8.GetBytes(secret));
            var hmacsha1 = new HMACSHA1();
            var hmasha1Hash = hmacsha1.ComputeHash(md5Hash);
            var sign = BitConverter.ToString(hmasha1Hash).Replace("-", "").ToLower();

            var link = $"https://{host}/get-{codec}/{sign}/{ts}{path}";

            return link;
        }

        #endregion Вспомогательные функции

        #region Основные функции

        /// <summary>
        /// Получение трека
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackId">Идентификатор трека</param>
        /// <returns></returns>
        public async Task<YTrack> GetAsync(YAuthStorage storage, string trackId)
        {
            return await new YGetTrackResponse(storage)
                .Create(trackId)
                .GetResponseAsync<YTrack>("track");
        }

        /// <summary>
        /// Получение трека
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackId">Идентификатор трека</param>
        /// <returns></returns>
        public YTrack Get(YAuthStorage storage, string trackId)
        {
            return GetAsync(storage, trackId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение метаданных для загрузки
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентифактор трека:идентификатор альбома}</param>
        /// <returns></returns>
        public async Task<YTrackDownloadInfoResponse> GetMetadataForDownloadAsync(YAuthStorage storage, string trackKey)
        {
            return await new YTrackDownloadInfoRequest(storage)
                .Create(trackKey)
                .GetResponseAsync<YTrackDownloadInfoResponse>();
        }

        /// <summary>
        /// Получение метаданных для загрузки
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентифактор трека:идентификатор альбома}</param>
        /// <returns></returns>
        public YTrackDownloadInfoResponse GetMetadataForDownload(YAuthStorage storage, string trackKey)
        {
            return GetMetadataForDownloadAsync(storage, trackKey).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение информации для формирования ссылки для загрузки
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="metadataInfo">Метаданные для загрузки</param>
        /// <returns></returns>
        public async Task<YStorageDownloadFileResponse> GetDownloadFileInfoAsync(YAuthStorage storage,
            YTrackDownloadInfoResponse metadataInfo)
        {
            return await new YStorageDownloadFileRequest(storage)
                .Create(metadataInfo.Src)
                .GetResponseAsync<YStorageDownloadFileResponse>();
        }

        /// <summary>
        /// Получение информации для формирования ссылки для загрузки
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="metadataInfo">Метаданные для загрузки</param>
        /// <returns></returns>
        public YStorageDownloadFileResponse GetDownloadFileInfo(YAuthStorage storage, YTrackDownloadInfoResponse metadataInfo)
        {
            return GetDownloadFileInfoAsync(storage, metadataInfo).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение ссылки для загрузки
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентифактор трека:идентификатор альбома}</param>
        /// <returns></returns>
        public string GetFileLink(YAuthStorage storage, string trackKey)
        {
            var mainDownloadResponse = GetMetadataForDownload(storage, trackKey);
            var storageDownloadResponse = GetDownloadFileInfo(storage, mainDownloadResponse);

            return BuildLinkForDownload(mainDownloadResponse, storageDownloadResponse);
        }

        /// <summary>
        /// Выгрузка в файл
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентифактор трека:идентификатор альбома}</param>
        /// <param name="filePath">Путь для файла</param>
        public void ExtractToFile(YAuthStorage storage, string trackKey, string filePath)
        {
            var fileLink = GetFileLink(storage, trackKey);

            try {
                using (var client = new WebClient()) {
                    client.DownloadFile(fileLink, filePath);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Получение двоичного массива данных
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентифактор трека:идентификатор альбома}</param>
        /// <returns></returns>
        public byte[] ExtractData(YAuthStorage storage, string trackKey)
        {
            var fileLink = GetFileLink(storage, trackKey);

            var bytes = default(byte[]);

            try {
                using (var client = new WebClient()) {
                    bytes = client.DownloadData(fileLink);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }

            return bytes;
        }

        /// <summary>
        /// Получение потока выгрузки
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентифактор трека:идентификатор альбома}</param>
        /// <param name="fileSize">Размер данных</param>
        /// <returns></returns>
        public YandexStreamTrack ExtractStream(YAuthStorage storage, string trackKey, int fileSize)
        {
            var fileLink = GetFileLink(storage, trackKey);
            return YandexStreamTrack.Open(new Uri(fileLink), fileSize);
        }

        /// <summary>
        /// Установка флага удаления из рекомендованных
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентифактор трека:идентификатор альбома}</param>
        /// <param name="value">Значение</param>
        /// <returns></returns>
        public async Task<YSetNotRecommendTrackResponse> SetNotRecommendAsync(YAuthStorage storage, string trackKey, bool value)
        {
            return await new YNotRecommendTrackRequest(storage)
                .Create(value, trackKey)
                .GetResponseAsync<YSetNotRecommendTrackResponse>();
        }

        /// <summary>
        /// Установка флага удаления из рекомендованных
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентифактор трека:идентификатор альбома}</param>
        /// <param name="value">Значение</param>
        /// <returns></returns>
        public YSetNotRecommendTrackResponse SetNotRecommend(YAuthStorage storage, string trackKey, bool value)
        {
            return SetNotRecommendAsync(storage, trackKey, value).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Установка флага "Нравится"
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентифактор трека:идентификатор альбома}</param>
        /// <param name="value">Значение</param>
        /// <returns></returns>
        public async Task<YSetLikedTrackResponse> SetLikedAsync(YAuthStorage storage, string trackKey, bool value)
        {
            return await new YSetLikedTrackRequest(storage)
                .Create(value, trackKey)
                .GetResponseAsync<YSetLikedTrackResponse>();
        }

        /// <summary>
        /// Установка флага "Нравится"
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентифактор трека:идентификатор альбома}</param>
        /// <param name="value">Значение</param>
        /// <returns></returns>
        public YSetLikedTrackResponse SetLiked(YAuthStorage storage, string trackKey, bool value)
        {
            return SetLikedAsync(storage, trackKey, value).GetAwaiter().GetResult();
        }

        #endregion Основные функции
    }
}