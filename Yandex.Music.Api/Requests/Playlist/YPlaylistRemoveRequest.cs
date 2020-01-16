using System.Collections.Generic;
using System.Net;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YPlaylistRemoveRequest : YRequest
    {
        public YPlaylistRemoveRequest(HttpContext context) : base(context)
        {
        }

        public HttpWebRequest Create(long kind, string sign, string experements, string userUid, string userLogin)
        {
            var uri = "https://music.yandex.ru/handlers/change-playlist.jsx";
            var request = GetRequest(uri,
                new KeyValuePair<string, string>("action", "delete"),
                new KeyValuePair<string, string>("kind", kind.ToString()),
                new KeyValuePair<string, string>("lang", "ru"),
                new KeyValuePair<string, string>("sign", sign),
                new KeyValuePair<string, string>("experiments", experements),
                new KeyValuePair<string, string>("external-domain", "music.yandex.ru"),
                new KeyValuePair<string, string>("overembed", "false")
            );
            request.Headers[HttpRequestHeader.Accept] = "application/json, text/javascript, */*; q=0.01";
            request.Headers["Accept-Encoding"] = "gzip, deflate, br";
            request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
            request.Headers["access-control-allow-methods"] = "[POST]";
            request.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";

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