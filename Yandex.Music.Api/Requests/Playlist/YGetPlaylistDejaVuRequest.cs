using System.Collections.Generic;
using System.Net;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YGetPlaylistDejaVuRequest : YRequest
    {
        public YGetPlaylistDejaVuRequest(HttpContext context) : base(context)
        {
        }

        public HttpWebRequest Create(string uid, string lang)
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                { "kinds", uid },
                { "lang", lang },
                { "owner", "yamusic-dejavu" },
                { "light", "true" },
                { "likeFilter", "all" },
                { "external-domain", "music.yandex.ru" },
                { "overembed", "false" },
                { "ncrnd", "0.13048851242872916" }
            };

            return GetRequest(YEndpoints.Playlist, query: query);
        }
    }
}