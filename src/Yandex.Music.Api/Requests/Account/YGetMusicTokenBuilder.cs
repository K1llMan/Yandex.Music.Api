using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Account
{
    [YOAuthMobile(WebRequestMethods.Http.Post, "/1/token")]
    internal class YGetMusicTokenBuilder : YRequestBuilder<YAccessToken, string>
    {
        public YGetMusicTokenBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override HttpContent GetContent(string tuple)
        {
            return new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "client_id", Constants.ClientId },
                { "client_secret", Constants.ClientSecret },
                { "grant_type", "x-token" },
                { "access_token", storage.AccessToken.AccessToken }
            });
        }

        protected override void SetCustomHeaders(HttpRequestHeaders headers)
        {
            headers.Remove("Authorization");

            base.SetCustomHeaders(headers);
        }
    }
}