using System.Collections.Generic;
using System.Net;
using System.Net.Http;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Auth
{
    [YOAuthRequest(WebRequestMethods.Http.Get, "token")]
    public class YAuthorizeBuilder : YRequestBuilder<YAuth, (string login, string password)>
    {
        #region Поля

        private static string CLIENT_ID = "23cabbbdc6cd418abb4b39c32c41195d";
        private static string CLIENT_SECRET = "53bc75238f0c4d08a118e51fe9203300";

        #endregion Поля

        public YAuthorizeBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override HttpContent GetContent((string login, string password) tuple)
        {
            return new FormUrlEncodedContent(new Dictionary<string, string> {
                { "grant_type", "password" },
                { "client_id", CLIENT_ID },
                { "client_secret", CLIENT_SECRET },
                { "username", tuple.login },
                { "password", tuple.password }
            });
        }
    }
}