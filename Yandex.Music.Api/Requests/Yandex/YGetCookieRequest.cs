using System.Net;

namespace Yandex.Music.Api.Requests.Yandex
{
    internal class YGetCookieRequest : YRequest
    {
        public YGetCookieRequest(HttpContext context) : base(context)
        {
        }

        public HttpWebRequest Create(string userLogin)
        {
            var request = GetRequest("https://matchid.adfox.yandex.ru/getcookie", WebRequestMethods.Http.Get);
            request.Headers["origin"] = "https://music.yandex.ru";
            request.Headers["referer"] = $"https://music.yandex.ru/users/{userLogin}/playlists";
            request.Headers["sec-fetch-mode"] = "cors";
            request.Headers["sec-fetch-site"] = "same-site";

            return request;
        }
    }
}