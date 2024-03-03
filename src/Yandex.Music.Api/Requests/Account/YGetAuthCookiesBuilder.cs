using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
#if NETSTANDARD2_0
using System.Text;
#endif

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Requests.Common;
using Yandex.Music.Api.Requests.Common.Attributes;

namespace Yandex.Music.Api.Requests.Account
{
    [YMobileProxyRequest(WebRequestMethods.Http.Post, "1/bundle/oauth/token_by_sessionid")]
    internal class YGetAuthCookiesBuilder : YRequestBuilder<YAccessToken, string>
    {
        public YGetAuthCookiesBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override void SetCustomHeaders(HttpRequestHeaders headers)
        {
            CookieCollection cookieCollection = new() {
                storage.Context.Cookies.GetCookies(new Uri("https://yandex.ru/")),
                storage.Context.Cookies.GetCookies(new Uri("https://passport.yandex.ru/"))
            };

#if NETCOREAPP
            headers.Add("Ya-Client-Cookie", string.Join(";", cookieCollection.Select(c => $"{c.Name}={c.Value}")));
#endif

#if NETSTANDARD2_0
            StringBuilder cookieValue = new();
            foreach (Cookie cookie in cookieCollection)
            {
                cookieValue.Append($"{cookie.Name}={cookie.Value};");
            }
            headers.Add("Ya-Client-Cookie", cookieValue.ToString());
#endif
            headers.Add("Ya-Client-Host", "passport.yandex.ru");
        }

        protected override HttpContent GetContent(string tuple)
        {
            return new FormUrlEncodedContent(new Dictionary<string, string> {
                { "client_id", YConstants.XClientId },
                { "client_secret", YConstants.XClientSecret }
            });
        }
    }
}