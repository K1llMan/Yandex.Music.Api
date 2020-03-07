using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Yandex
{
    internal class YGetCookieRequest : YRequest
    {
        public YGetCookieRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create(string userLogin)
        {
            var request = FormRequest("https://matchid.adfox.yandex.ru/getcookie");
            request.Headers["origin"] = "https://music.yandex.ru";
            request.Headers["referer"] = $"https://music.yandex.ru/users/{userLogin}/playlists";
            request.Headers["sec-fetch-mode"] = "cors";
            request.Headers["sec-fetch-site"] = "same-site";

            return this;
        }
    }
}