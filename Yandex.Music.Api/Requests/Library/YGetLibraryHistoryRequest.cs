using System.Collections.Generic;
using System.Net;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Library
{
    internal class YGetLibraryHistoryRequest : YRequest
    {
        public YGetLibraryHistoryRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create()
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                { "owner", storage.User.Login },
                { "lang", storage.User.Lang },
                { "filter", "history" },
                { "likeFilter", "all" },
                { "external-domain", "music.yandex.ru" },
                { "overembed", "no" },
                { "ncrnd", "0.671046085811837" }
            };

            var request = FormRequest(YEndpoints.Library, query: query);

            request.Headers[HttpRequestHeader.Accept] = "application/json, text/javascript, */*; q=0.01";
            request.Headers["Accept-Encoding"] = "gzip, deflate, br";
            request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
            request.Headers["access-control-allow-methods"] = "[POST]";
            request.Headers["Sec-Fetch-Mode"] = "cors";
            request.Headers["X-Current-UID"] = storage.User.Uid;
            request.Headers["X-Requested-With"] = "XMLHttpRequest";
            request.Headers["X-Retpath-Y"] = $"https%3A%2F%2Fmusic.yandex.ru%2Fusers%2F{storage.User.Uid}%2Fplaylists";

            request.Headers["origin"] = "https://music.yandex.ru";
            request.Headers["referer"] = $"https://music.yandex.ru/users/{storage.User.Uid}/playlists";
            request.Headers["sec-fetch-mode"] = "cors";
            request.Headers["sec-fetch-site"] = "same-site";

            return this;
        }
    }
}