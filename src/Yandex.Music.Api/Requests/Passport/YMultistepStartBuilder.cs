using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Passport;
using Yandex.Music.Api.Requests.Common;
using Yandex.Music.Api.Requests.Common.Attributes;

namespace Yandex.Music.Api.Requests.Passport
{
    [YPassportRequest(WebRequestMethods.Http.Post, "pwl-yandex/api/passport/track/create")]
    public class YMultistepStartBuilder : YRequestBuilder<YMultistepStart, string>
    {
        public YMultistepStartBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override HttpContent GetContent(string tuple)
        {
            Dictionary<string, string> formData = new()
            {
                { "login", tuple },
                { "track_id", storage.AuthToken.TrackId },
                { "display_language", storage.DisplayLanguage },
                { "retpath", string.Empty },
                { "can_send_push_code", "true" },
                { "check_for_xtokens_for_pictures", "false" },
                { "force_check_for_protocols", "true" },
                { "app_id", "ru.yandex.music" },
                { "am_version_name", "7.50.2(750024597)" },
                { "app_platform", "android" },
                { "app_version_name", "2026.02.3 #135rur" },
                { "device_id", storage.DeviceId },
                { "deviceId", storage.DeviceId },
                { "device_connection_type", "9" }
            };

            return new FormUrlEncodedContent(formData);
        }
    }
}