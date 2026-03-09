using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Passport;
using Yandex.Music.Api.Requests.Common;
using Yandex.Music.Api.Requests.Common.Attributes;

namespace Yandex.Music.Api.Requests.Passport
{
    [YPassportRequest(WebRequestMethods.Http.Get, "pwl-yandex/api/passport/auth/rfc-otp")]
    public class YRfcOtpBuilder : YPassportRequestBuilder<YPassportUser, string>
    {
        public YRfcOtpBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override HttpContent GetContent(string tuple)
        {
            Dictionary<string, string> formData = new()
            {
                { "track_id", storage.AuthToken.TrackId },
                { "otp", tuple }
            };

            return new FormUrlEncodedContent(formData);
        }
    }
}