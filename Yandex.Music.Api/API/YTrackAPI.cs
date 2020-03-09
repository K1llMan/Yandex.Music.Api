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

        public async Task<YTrack> GetAsync(YAuthStorage storage, string trackId)
        {
            return await new YGetTrackResponse(storage)
                .Create(trackId)
                .GetResponseAsync<YTrack>("track");
        }

        public YTrack Get(YAuthStorage storage, string trackId)
        {
            return GetAsync(storage, trackId).GetAwaiter().GetResult();
        }

        public async Task<YTrackDownloadInfoResponse> GetMetadataForDownloadAsync(YAuthStorage storage, string trackKey)
        {
            return await new YTrackDownloadInfoRequest(storage)
                .Create(trackKey)
                .GetResponseAsync<YTrackDownloadInfoResponse>();
        }

        public YTrackDownloadInfoResponse GetMetadataForDownload(YAuthStorage storage, string trackKey)
        {
            return GetMetadataForDownloadAsync(storage, trackKey).GetAwaiter().GetResult();
        }

        public async Task<YStorageDownloadFileResponse> GetDownloadFileInfoAsync(YAuthStorage storage,
            YTrackDownloadInfoResponse metadataInfo)
        {
            return await new YStorageDownloadFileRequest(storage)
                .Create(metadataInfo.Src)
                .GetResponseAsync<YStorageDownloadFileResponse>();
        }

        public YStorageDownloadFileResponse GetDownloadFileInfo(YAuthStorage storage, YTrackDownloadInfoResponse metadataInfo)
        {
            return GetDownloadFileInfoAsync(storage, metadataInfo).GetAwaiter().GetResult();
        }

        public string GetFileLink(YAuthStorage storage, string trackKey)
        {
            var mainDownloadResponse = GetMetadataForDownload(storage, trackKey);
            var storageDownloadResponse = GetDownloadFileInfo(storage, mainDownloadResponse);

            return BuildLinkForDownload(mainDownloadResponse, storageDownloadResponse);
        }

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

        public YandexStreamTrack ExtractStream(YAuthStorage storage, string trackKey, int fileSize)
        {
            var fileLink = GetFileLink(storage, trackKey);
            return YandexStreamTrack.Open(new Uri(fileLink), fileSize);
        }

        public async Task<YSetNotRecommendTrackResponse> SetNotRecommendAsync(YAuthStorage storage, string trackKey, bool value)
        {
            return await new YNotRecommendTrackRequest(storage)
                .Create(value, trackKey)
                .GetResponseAsync<YSetNotRecommendTrackResponse>();
        }

        public YSetNotRecommendTrackResponse SetNotRecommend(YAuthStorage storage, string trackKey, bool value)
        {
            return SetNotRecommendAsync(storage, trackKey, value).GetAwaiter().GetResult();
        }

        public async Task<YSetLikedTrackResponse> SetLikedAsync(YAuthStorage storage, string trackKey, bool value)
        {
            return await new YSetLikedTrackRequest(storage)
                .Create(value, trackKey)
                .GetResponseAsync<YSetLikedTrackResponse>();
        }

        public YSetLikedTrackResponse SetLiked(YAuthStorage storage, string trackKey, bool value)
        {
            return SetLikedAsync(storage, trackKey, value).GetAwaiter().GetResult();
        }

        #endregion Основные функции
    }
}