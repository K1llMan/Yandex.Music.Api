using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Requests.Common;
using Yandex.Music.Api.Requests.Common.Attributes;

namespace Yandex.Music.Api.Requests.MobileProxy
{
    [YMobileProxyRequest(WebRequestMethods.Http.Post, "1/token")]
    public class YGetAccessTokenBuilder : YRequestBuilder<YAccessToken, string>
    {
        public YGetAccessTokenBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override HttpContent GetContent(string tuple)
        {
            Dictionary<string, string> content = new Dictionary<string, string>
            {
                { "client_id", YConstants.XClientId2 },
                { "client_secret", YConstants.XClientSecret2 },
                { "access_token", tuple },
                { "grant_type", "x-token" }
            };

            return new FormUrlEncodedContent(content);
        }
    }
}