using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Passport;
using Yandex.Music.Api.Requests.Common;
using Yandex.Music.Api.Requests.Common.Attributes;

namespace Yandex.Music.Api.Requests.Passport
{
    [YPassportRequest(WebRequestMethods.Http.Post, "pwl-yandex/api/passport/auth/multistep_start")]
    public class YMultistepStartBuilder : YPassportRequestBuilder<YMultistepStart, string>
    {
        private class RequestData
        {
            [JsonPropertyName("login")]
            public string Login { get; set; }
            [JsonPropertyName("track_id")]
            public string TrackId { get; set; }
            [JsonPropertyName("display_language")]
            public string DisplayLanguage { get; set; }
            [JsonPropertyName("retpath")]
            public string Retpath { get; set; }
            [JsonPropertyName("can_send_push_code")]
            public bool CanSendPushCode { get; set; }
            [JsonPropertyName("check_for_xtokens_for_pictures")]
            public bool CheckForXtokensForPictures { get; set; }
            [JsonPropertyName("force_check_for_protocols")]
            public bool ForceCheckForProtocols { get; set; }
            [JsonPropertyName("app_id")]
            public string AppId { get; set; }
            [JsonPropertyName("am_version_name")]
            public string AmVersionName { get; set; }
            [JsonPropertyName("app_platform")]
            public string AppPlatform { get; set; }
            [JsonPropertyName("app_version_name")]
            public string AppVersionName { get; set; }
            [JsonPropertyName("device_id")]
            public string Device_Id { get; set; }
            [JsonPropertyName("deviceId")]
            public string DeviceId { get; set; }
            [JsonPropertyName("device_connection_type")]
            public string DeviceConnectionType { get; set; }
        }
        
        public YMultistepStartBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override HttpContent GetContent(string tuple)
        {
            return GetJsonContent(new RequestData {
                Login = tuple,
                TrackId = storage.AuthToken.TrackId,
                DisplayLanguage = storage.DisplayLanguage,
                Retpath = string.Empty,
                CanSendPushCode = true,
                CheckForXtokensForPictures = false,
                ForceCheckForProtocols = true,
                AppId = "ru.yandex.music",
                AmVersionName = "7.50.2(750024597)",
                AppPlatform = "android",
                AppVersionName = "2026.02.3 #135rur",
                DeviceId = storage.DeviceId,
                Device_Id = storage.DeviceId,
                DeviceConnectionType = "9"
            });
        }
    }
}