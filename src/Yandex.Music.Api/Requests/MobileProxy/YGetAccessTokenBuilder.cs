using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Requests.Common;
using Yandex.Music.Api.Requests.Common.Attributes;

namespace Yandex.Music.Api.Requests.MobileProxy
{
    [YMobileProxyRequest(WebRequestMethods.Http.Post, "1/token")]
    public class YGetAccessTokenBuilder : YRequestBuilder<YAccessToken, YAccessToken>
    {
        public YGetAccessTokenBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override HttpContent GetContent(YAccessToken tuple)
        {
            Dictionary<string, string> content = new Dictionary<string, string>
            {
                { "client_id", YConstants.ClientId },
                { "client_secret", YConstants.ClientSecret },
                { "access_token", tuple.AccessToken },
                { "grant_type", "x-token" }
            };

            return new FormUrlEncodedContent(content);
        }

        protected override void SetAuthorization(HttpRequestHeaders headers)
        {
            if (headers.Contains("Authorization"))
                headers.Remove("Authorization");
        }
    }
}