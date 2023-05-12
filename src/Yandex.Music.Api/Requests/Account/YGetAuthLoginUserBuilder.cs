using System.Collections.Generic;
using System.Net;
using System.Net.Http;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Account
{
    [YPassportRequest(WebRequestMethods.Http.Post, "registration-validations/auth/multi_step/start")]
    internal class YGetAuthLoginUserBuilder : YRequestBuilder<YAuthTypes, (string token, string login)>
    {
        public YGetAuthLoginUserBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override HttpContent GetContent((string token, string login) tuple)
        {
            return new FormUrlEncodedContent(new Dictionary<string, string> {
                { "csrf_token", tuple.token },
                { "login", tuple.login }
            });
        }
    }
}