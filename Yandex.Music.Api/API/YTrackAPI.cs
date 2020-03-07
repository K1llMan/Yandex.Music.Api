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
        #region Поля

        private readonly YandexMusicApi api;

        #endregion Поля

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
            var request = new YGetTrackResponse(storage.Context).Create(trackId);

            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await api.GetDataFromResponseAsync<YTrack>(storage.Context, response, "track");
            }
        }

        public YTrack Get(YAuthStorage storage, string trackId)
        {
            return GetAsync(storage, trackId).GetAwaiter().GetResult();
        }

        public async Task<YTrackDownloadInfoResponse> GetMetadataForDownloadAsync(YAuthStorage storage, string trackKey)
        {
            long time = storage.Context.GetTimeInterval();
            var request =
                new YTrackDownloadInfoRequest(storage.Context).Create(trackKey, time, storage.User.Uid, storage.User.Login);

            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await api.GetDataFromResponseAsync<YTrackDownloadInfoResponse>(storage.Context, response);
            }
        }

        public YTrackDownloadInfoResponse GetMetadataForDownload(YAuthStorage storage, string trackKey)
        {
            return GetMetadataForDownloadAsync(storage, trackKey).GetAwaiter().GetResult();
        }

        public async Task<YStorageDownloadFileResponse> GetDownloadFileInfoAsync(YAuthStorage storage,
            YTrackDownloadInfoResponse metadataInfo)
        {
            long time = storage.Context.GetTimeInterval();
            var request = new YStorageDownloadFileRequest(storage.Context).Create(metadataInfo.Src, time, storage.User.Login);

            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await api.GetDataFromResponseAsync<YStorageDownloadFileResponse>(storage.Context, response);
            }
        }

        public YStorageDownloadFileResponse GetDownloadFileInfo(YAuthStorage storage, YTrackDownloadInfoResponse metadataInfo)
        {
            return GetDownloadFileInfoAsync(storage, metadataInfo).GetAwaiter().GetResult();
        }

        public string GetFileLink(YAuthStorage storage, string trackKey)
        {
            YTrackDownloadInfoResponse mainDownloadResponse = GetMetadataForDownload(storage, trackKey);
            YStorageDownloadFileResponse storageDownloadResponse = GetDownloadFileInfo(storage, mainDownloadResponse);

            return BuildLinkForDownload(mainDownloadResponse, storageDownloadResponse);
        }

        public void ExtractToFile(YAuthStorage storage, string trackKey, string filePath)
        {
            string fileLink = GetFileLink(storage, trackKey);

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
            string fileLink = GetFileLink(storage, trackKey);

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
            string fileLink = GetFileLink(storage, trackKey);
            return YandexStreamTrack.Open(new Uri(fileLink), fileSize);
        }

        public async Task<YNotRecommendTrackResponse> NotRecommendAsync(YAuthStorage storage, string trackKey)
        {
            var request = new YNotRecommendTrackRequest(storage.Context).Create(trackKey, storage.Context.GetTimeInterval(),
                storage.User.Sign, storage.User.Uid, storage.User.Login);
            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await api.GetDataFromResponseAsync<YNotRecommendTrackResponse>(storage.Context, response);
            }
        }

        public YNotRecommendTrackResponse NotRecommend(YAuthStorage storage, string trackKey)
        {
            return NotRecommendAsync(storage, trackKey).GetAwaiter().GetResult();
        }

        public async Task<YUnDislikeTrackResponse> UnderNotRecommendAsync(YAuthStorage storage, string trackKey)
        {
            var request = new YUnDislikeTrackRequest(storage.Context).Create(trackKey, storage.Context.GetTimeInterval(),
                storage.User.Sign, storage.User.Uid, storage.User.Login);

            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await api.GetDataFromResponseAsync<YUnDislikeTrackResponse>(storage.Context, response);
            }
        }

        public YUnDislikeTrackResponse UnderNotRecommend(YAuthStorage storage, string trackKey)
        {
            return UnderNotRecommendAsync(storage, trackKey).GetAwaiter().GetResult();
        }

        public async Task<YSetLikedTrackResponse> SetLikedAsync(YAuthStorage storage, string trackKey, bool value)
        {
            var request = new YSetLikedTrackRequest(storage.Context).Create(value, trackKey, storage.Context.GetTimeInterval(),
                storage.User.Sign, storage.User.Uid, storage.User.Login);

            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await api.GetDataFromResponseAsync<YSetLikedTrackResponse>(storage.Context, response);
            }
        }

        public YSetLikedTrackResponse SetLiked(YAuthStorage storage, string trackKey, bool value)
        {
            return SetLikedAsync(storage, trackKey, value).GetAwaiter().GetResult();
        }

        public async Task<YAddLikedTrackResponse> ChangeLikedAsync(YAuthStorage storage, string trackKey, bool value)
        {
            var request = new YAddLikedTrackRequest(storage.Context).Create(value, trackKey, storage.Context.GetTimeInterval(),
                storage.User.Sign, storage.User.Uid, storage.User.Login);

            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await api.GetDataFromResponseAsync<YAddLikedTrackResponse>(storage.Context, response);
            }
        }

        public YAddLikedTrackResponse ChangeLiked(YAuthStorage storage, string trackKey, bool value)
        {
            return ChangeLikedAsync(storage, trackKey, value).GetAwaiter().GetResult();
        }

        public YTrackAPI(YandexMusicApi yandexApi)
        {
            api = yandexApi;
        }

        #endregion Основные функции
    }
}