using System.Collections.Generic;
using System.Net;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YGetPlaylistOfDayRequest : YRequest
    {
        public YGetPlaylistOfDayRequest(HttpContext context) : base(context)
        {
        }

        public HttpWebRequest Create(string uid, string lang)
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                { "kinds", uid },
                { "lang", lang },
                { "owner", "yamusic-daily" },
                { "light", "true" },
                { "external-domain", "music.yandex.ru" },
                { "overembed", "false" },
                { "ncrnd", "ncrnd=0.9083773647705418" }
            };

            return GetRequest(YEndpoints.Playlist, query: query);
        }
    }
}