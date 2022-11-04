using System.Net;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Account
{
    [YApiRequest(WebRequestMethods.Http.Get, "account/status")]
    public class YGetAuthInfoBuilder: YRequestBuilder<YResponse<YAccountResult>, object>
    {
        public YGetAuthInfoBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }
    }
}