using System.Collections.Generic;
using System.Net;
using System.Net.Http;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Account
{
    [YOAuthRequest(WebRequestMethods.Http.Post, "token")]
    public class YAuthorizeBuilder : YRequestBuilder<YAccessToken, (string login, string password)>
    {
        public YAuthorizeBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override HttpContent GetContent((string login, string password) tuple)
        {
            return new FormUrlEncodedContent(new Dictionary<string, string> {
                { "grant_type", "password" },
                { "client_id", Constants.ClientId },
                { "client_secret", Constants.ClientSecret },
                { "username", tuple.login },
                { "password", tuple.password }
            });
        }
    }
}