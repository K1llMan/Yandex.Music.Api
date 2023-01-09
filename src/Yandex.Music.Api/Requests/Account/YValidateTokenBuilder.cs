using System.Collections.Specialized;
using System.Net;
using System.Net.Http.Headers;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Requests.Common;

namespace Yandex.Music.Api.Requests.Account
{
    [YMobileProxyRequest(WebRequestMethods.Http.Get, "/1/bundle/account/short_info/")]
    internal class YValidateTokenBuilder : YRequestBuilder<YShortInfo, string>
    {
        public YValidateTokenBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override NameValueCollection GetQueryParams(string tuple)
        {
            NameValueCollection query = new() {
                { "avatar_size", "islands-300" }
            };

            return query;
        }

        protected override void SetCustomHeaders(HttpRequestHeaders headers)
        {
            headers.Add("Ya-Consumer-Authorization", $"OAuth {storage.AccessToken.AccessToken}");
        }
    }
}