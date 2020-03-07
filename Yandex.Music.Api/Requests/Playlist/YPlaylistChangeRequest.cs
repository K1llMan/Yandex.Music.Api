using System.Collections.Generic;
using System.Net;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YPlaylistChangeRequest : YRequest
    {
        public YPlaylistChangeRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create(string name)
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                {"action", "add"},
                {"title", name},
                {"lang", "ru"},
                {"sign", storage.User.Sign },
                {"experiments", storage.User.Experiments },
                {"external-domain", "music.yandex.ru"},
                {"overembed", "false"}
            };

            var request = FormRequest(YEndpoints.ChangePlaylist, body: GetQueryString(query));

            request.Headers[HttpRequestHeader.Accept] = "application/json, text/javascript, */*; q=0.01";
            request.Headers["Accept-Encoding"] = "gzip, deflate, br";
            request.Headers["Accept-Language"] = "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7";
            request.Headers["access-control-allow-methods"] = "[POST]";
            request.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";

            request.Headers["X-Current-UID"] = storage.User.Uid;
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