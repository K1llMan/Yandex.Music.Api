using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Requests.Common;
using Yandex.Music.Api.Requests.Common.Attributes;

namespace Yandex.Music.Api.Requests.MobileProxy
{
    [YMobileProxyRequest(WebRequestMethods.Http.Post, "1/bundle/oauth/token_by_sessionid")]
    internal class YGetTokenBySessionIdBuilder : YRequestBuilder<YAccessToken, string>
    {
        public YGetTokenBySessionIdBuilder(YandexMusicApi yandex, AuthStorage auth) : base(yandex, auth)
        {
        }

        protected override void SetCustomHeaders(HttpRequestHeaders headers)
        {
            var cookies = storage.Context.Cookies.GetAllCookies()
                .Where(x => x.Domain.EndsWith("yandex.ru"))
                .Select(x => new
                {
                    x.Name,
                    x.Value
                });
            
            headers.Add("Ya-Client-Cookie", string.Join(";", cookies.Select(c => $"{c.Name}={c.Value}")));
            headers.Add("Ya-Client-Host", "passport.yandex.ru");
        }

        protected override HttpContent GetContent(string tuple)
        {
            Dictionary<string, string> content = new Dictionary<string, string>
            {
                { "client_id", YConstants.XClientId },
                { "client_secret", YConstants.XClientSecret },
                { "track_id", storage.AuthToken.TrackId }
            };

            return new FormUrlEncodedContent(content);
        }
    }
}