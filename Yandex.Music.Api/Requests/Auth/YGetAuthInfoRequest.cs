using System.Collections.Generic;
using System.Net;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Auth
{
    internal class YGetAuthInfoRequest : YRequest
    {
        public YGetAuthInfoRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create()
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                { "external-domain", "music.yandex.ru" },
                { "overembed", "no" },
                { "__t", storage.Context.GetTimeInterval().ToString() }
            };

            var request = FormRequest("https://music.yandex.ru/api/v2.1/handlers/auth", query: query);

            request.Headers[HttpRequestHeader.Accept] = "application/json; q=1.0, text/*; q=0.8, */*; q=0.1";
            request.Headers["Accept-Encoding"] = "gzip, deflate, br";
            request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
            request.Headers["access-control-allow-methods"] = "[POST]";
            request.Headers["Sec-Fetch-Mode"] = "cors";
            request.Headers["X-Requested-With"] = "XMLHttpRequest";
            request.Headers["X-Retpath-Y"] = $"https%3A%2F%2Fmusic.yandex.ru%2Fusers%2F{storage.User.Login}%2Fplaylists";

            request.Headers["origin"] = "https://music.yandex.ru";
            request.Headers["referer"] = $"https://music.yandex.ru/users/{storage.User.Login}/playlists";
            request.Headers["sec-fetch-mode"] = "cors";
            request.Headers["sec-fetch-site"] = "same-site";

            return this;
        }
    }
}