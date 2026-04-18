using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests.Common;
using Yandex.Music.Api.Requests.Common.Attributes;

namespace Yandex.Music.Api.Requests.Passport
{
    [YPassportRequest(WebRequestMethods.Http.Get, "pwl-yandex")]
    public class YPwlYandexBuilder : YRequestBuilder<HttpResponseMessage, string>
    {
        public YPwlYandexBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }
        
        protected override NameValueCollection GetQueryParams(string tuple)
        {
            return new NameValueCollection {
                { "lang", storage.Language },
                { "locale", string.Empty },
                { "app_id", "ru.yandex.music" },
                { "app_platform", "android" },
                { "manufacturer", "OnePlus" },
                { "model", "ONEPLUS" },
                { "am_version_name", "7.50.2(750024597)" },
                { "app_version_name", "2026.02.1" },
                { "device_id", storage.DeviceId },
                { "am_version", "7.50.2" },
                { "app_signature", "production" },
                { "uuid", Guid.NewGuid().ToString().Replace("-", string.Empty) },
                { "connection_type", "9" },
                { "cause", "am" }
            };
        }
    }
}