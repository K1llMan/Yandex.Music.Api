using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public partial class YTrackAPI : YCommonAPI
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
        /// <param name="trackIds">Идентификаторы треков</param>
        /// <returns></returns>
        public Task<YResponse<List<YTrack>>> GetAsync(AuthStorage storage, IEnumerable<string> trackIds)
        {
            return new YGetTracksBuilder(api, storage)
                .Build(trackIds)
                .GetResponseAsync();
        }

        /// <summary>
        /// Получение метаданных для загрузки
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентифактор трека:идентификатор альбома}</param>
        /// <param name="direct">Должен ли ответ содержать прямую ссылку на загрузку</param>
        /// <returns></returns>
        public Task<YResponse<List<YTrackDownloadInfo>>> GetMetadataForDownloadAsync(AuthStorage storage, string trackKey, bool direct = false)
        {
            return new YTrackDownloadInfoBuilder(api, storage)
                .Build((trackKey, direct))
                .GetResponseAsync();
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
        /// Получение ссылки для загрузки
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентификатор трека:идентификатор альбома}</param>
        /// <returns></returns>
        public async Task<string> GetFileLinkAsync(AuthStorage storage, string trackKey)
        {
            YResponse<List<YTrackDownloadInfo>> meta = await GetMetadataForDownloadAsync(storage, trackKey);
            YTrackDownloadInfo info = meta.Result
                .OrderByDescending(i => i.BitrateInKbps)
                .First(m => m.Codec == "mp3");
            YStorageDownloadFile storageDownload = await GetDownloadFileInfoAsync(storage, info);
            return BuildLinkForDownload(info, storageDownload);
        }

        /// <summary>
        /// Получение ссылки для загрузки
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public Task<string> GetFileLinkAsync(AuthStorage storage, YTrack track)
        {
            return GetFileLinkAsync(storage, track.GetKey().ToString());
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
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public Task<YResponse<YTrackSupplement>> GetSupplementAsync(AuthStorage storage, YTrack track)
        {
            return new YGetTrackSupplementBuilder(api, storage)
                .Build(track.GetKey().ToString())
                .GetResponseAsync();
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
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public Task<YResponse<YTrackSimilar>> GetSimilarAsync(AuthStorage storage, YTrack track)
        {
            return new YGetTrackSimilarBuilder(api, storage)
                .Build(track.GetKey().ToString())
                .GetResponseAsync();
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
        public async Task ExtractToFileAsync(AuthStorage storage, string trackKey, string filePath)
        {
            string url = await GetFileLinkAsync(storage, trackKey);
            await new DataDownloader(storage).ToFile(url, filePath);
        }

        /// <summary>
        /// Выгрузка в файл
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <param name="filePath">Путь для файла</param>
        public Task ExtractToFileAsync(AuthStorage storage, YTrack track, string filePath)
        {
            return ExtractToFileAsync(storage, track.GetKey().ToString(), filePath);
        }

        #endregion В файл

        #region В массив байт

        /// <summary>
        /// Получение двоичного массива данных
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентификатор трека:идентификатор альбома}</param>
        /// <returns></returns>
        public async Task<byte[]> ExtractDataAsync(AuthStorage storage, string trackKey)
        {
            string url = await GetFileLinkAsync(storage, trackKey);
            return await new DataDownloader(storage).AsBytes(url);
        }

        /// <summary>
        /// Получение двоичного массива данных
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public Task<byte[]> ExtractDataAsync(AuthStorage storage, YTrack track)
        {
            return ExtractDataAsync(storage, track.GetKey().ToString());
        }

        #endregion В массив байт

        #region В поток

        /// <summary>
        /// Получение потока данных
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackKey">Ключ трека в формате {идентификатор трека:идентификатор альбома}</param>
        /// <returns></returns>
        public async Task<Stream> ExtractStreamAsync(AuthStorage storage, string trackKey)
        {
            string url = await GetFileLinkAsync(storage, trackKey);
            return await new DataDownloader(storage).AsStream(url);
        }

        /// <summary>
        /// Получение потока данных
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public Task<Stream> ExtractStreamAsync(AuthStorage storage, YTrack track)
        {
            return ExtractStreamAsync(storage, track.GetKey().ToString());
        }

        #endregion В поток

        #endregion Получение данных трека

        #endregion Основные функции
    }
}