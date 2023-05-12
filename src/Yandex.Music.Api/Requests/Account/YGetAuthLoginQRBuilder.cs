using System.Collections.Generic;
using System.Net;
using System.Net.Http;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Account
{
    [YPassportRequest(WebRequestMethods.Http.Post, "auth/new/magic/status/")]
    internal class YGetAuthLoginQRBuilder : YRequestBuilder<YAuthQRStatus, string>
    {
        public YGetAuthLoginQRBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override HttpContent GetContent(string tuple)
        {
            return new FormUrlEncodedContent(new Dictionary<string, string> {
                { "csrf_token", storage.AuthToken.CsfrToken },
                { "track_id", storage.AuthToken.TrackId }
            });
        }
    }
}