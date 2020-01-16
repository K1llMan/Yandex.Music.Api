using System.Net;

namespace Yandex.Music.Api.Requests.Library
{
    internal class YGetLibraryPlaylistRequest : YRequest
    {
        public YGetLibraryPlaylistRequest(HttpContext context) : base(context)
        {
        }

        public HttpWebRequest Create(string userLogin, string userLang, string userUid)
        {
            var url =
                $"https://music.yandex.ru/handlers/library.jsx?owner={userLogin}&filter=playlists&likeFilter=all&lang={userLang}&external-domain=music.yandex.ru&overembed=false&ncrnd=0.17447934315877878";

            var request = GetRequest(url, WebRequestMethods.Http.Get);
            request.Headers[HttpRequestHeader.Accept] = "application/json, text/javascript, */*; q=0.01";
            request.Headers["Accept-Encoding"] = "gzip, deflate, br";
            request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
            request.Headers["access-control-allow-methods"] = "[POST]";
            request.Headers["Sec-Fetch-Mode"] = "cors";
            request.Headers["X-Current-UID"] = userUid;
            request.Headers["X-Requested-With"] = "XMLHttpRequest";
            request.Headers["X-Retpath-Y"] = $"https%3A%2F%2Fmusic.yandex.ru%2Fusers%2F{userLogin}%2Fplaylists";

            request.Headers["origin"] = "https://music.yandex.ru";
            request.Headers["referer"] = $"https://music.yandex.ru/users/{userLogin}/playlists";
            request.Headers["sec-fetch-mode"] = "cors";
            request.Headers["sec-fetch-site"] = "same-site";

            return request;
        }
    }
}