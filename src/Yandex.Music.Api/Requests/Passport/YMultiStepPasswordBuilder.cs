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

        protected override void SetCustomHeaders(HttpRequestHeaders headers)
        {
            if (string.IsNullOrWhiteSpace(storage.AuthToken.CsfrToken))
                throw new AuthenticationException("Не найдена сессия входа. Выполните {nameof(CreateTrackAsync)} перед использованием.");

            headers.Add("x-csrf-token", storage.AuthToken.CsfrToken);
        }

        protected override HttpContent GetContent(string tuple)
        {
            // Dictionary<string, string> formData = new()
            // {
            //     { "track_id", storage.AuthToken.TrackId },
            //     { "password", tuple }
            // };

            return GetJsonContent(new
            {
                storage.AuthToken.TrackId,
                Password = tuple
            });
        }
    }
}