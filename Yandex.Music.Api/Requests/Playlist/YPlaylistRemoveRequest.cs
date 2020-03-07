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
            Dictionary<string, string> query = new Dictionary<string, string> {
                {"action", "delete"},
                {"kind", kind.ToString()},
                {"lang", "ru"},
                {"sign", sign},
                {"experiments", experements},
                {"external-domain", "music.yandex.ru"},
                {"overembed", "false"}
            };

            var request = GetRequest(YEndpoints.ChangePlaylist, body: GetQueryString(query));

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