using System.Collections.Specialized;
using System.Net;
using System.Net.Http;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests.Common;
using Yandex.Music.Api.Requests.Common.Attributes;

namespace Yandex.Music.Api.Requests.Account
{
    [YPassportRequest(WebRequestMethods.Http.Get, "am")]
    internal class YGetAuthMethodsBuilder : YRequestBuilder<HttpResponseMessage, string>
    {
        public YGetAuthMethodsBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override NameValueCollection GetQueryParams(string tuple)
        {
            return new NameValueCollection {
                { "app_platform", "android" }
            };
        }
    }
}