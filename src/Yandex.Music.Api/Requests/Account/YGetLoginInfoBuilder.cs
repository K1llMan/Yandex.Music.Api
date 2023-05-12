using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Account
{
    [YLoginRequest(WebRequestMethods.Http.Get, "info")]
    public class YGetLoginInfoBuilder : YRequestBuilder<YLoginInfo, object>
    {
        public YGetLoginInfoBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }
    }
}