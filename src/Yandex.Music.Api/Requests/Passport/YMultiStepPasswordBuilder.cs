using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Passport;
using Yandex.Music.Api.Requests.Common;
using Yandex.Music.Api.Requests.Common.Attributes;

namespace Yandex.Music.Api.Requests.Passport
{
    [YPassportRequest(WebRequestMethods.Http.Post, "pwl-yandex/api/passport/auth/multistep_password")]
    public class YMultiStepPasswordBuilder : YPassportRequestBuilder<YPassportUser, string>
    {
        public YMultiStepPasswordBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override HttpContent GetContent(string tuple)
        {
            return GetJsonContent(new
            {
                track_id = storage.AuthToken.TrackId,
                password = tuple
            });
        }
    }
}