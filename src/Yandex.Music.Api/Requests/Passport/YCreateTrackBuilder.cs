using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Passport;
using Yandex.Music.Api.Requests.Common;
using Yandex.Music.Api.Requests.Common.Attributes;

namespace Yandex.Music.Api.Requests.Passport
{
    [YPassportRequest(WebRequestMethods.Http.Post, "pwl-yandex/api/passport/track/create")]
    public class YCreateTrackBuilder : YRequestBuilder<YPassportTrack, string>
    {
        public YCreateTrackBuilder(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        protected override HttpContent GetContent(string tuple)
        {
            return GetJsonContent(new
            {
                display_language = storage.DisplayLanguage,
                language = storage.Language,
                country = storage.Country,
                app_id = "ru.yandex.music",
                app_version_name = "2026.02.3 #135rur",
                retpath = string.Empty,
                device_id = storage.DeviceId,
                uid = string.Empty,
                device_connection_type = "9"
            });
        }

        protected override void SetCustomHeaders(HttpRequestHeaders headers)
        {
            headers.Add("x-csrf-token", storage.AuthToken.CsfrToken);
            headers.Add("process-uuid", storage.ProcessUuid.ToString());
        }
    }
}