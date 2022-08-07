using System.Collections.Generic;
using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;

namespace Yandex.Music.Api.Requests.Auth
{
    internal class YAuthorizeRequest : YRequest<YAuth>
    {
        #region Поля

        private static string CLIENT_ID = "23cabbbdc6cd418abb4b39c32c41195d";
        private static string CLIENT_SECRET = "53bc75238f0c4d08a118e51fe9203300";

        #endregion Поля

        public YRequest<YAuth> Create(string login, string password)
        {
            List<KeyValuePair<string, string>> headers = new()
            {
                YRequestHeaders.Get(YHeader.ContentType, "application/x-www-form-urlencoded")
            };

            Dictionary<string, string> body = new()
            {
                { "grant_type", "password" },
                { "client_id", CLIENT_ID },
                { "client_secret", CLIENT_SECRET },
                { "username", login },
                { "password", password }
            };

            FormRequest($"{YEndpoints.OAuth}/token", WebRequestMethods.Http.Post, headers: headers, body: GetQueryString(body));

            return this;
        }

        public YAuthorizeRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }
    }
}