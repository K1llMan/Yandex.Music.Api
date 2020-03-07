using System.Collections.Generic;
using System.Net;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YGetPlaylistRequest : YRequest
    {
        public YGetPlaylistRequest(HttpContext context) : base(context)
        {
        }

        public HttpWebRequest Create(string kinds)
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                {"owner", "music.partners"},
                {"kinds", kinds}
            };

            return GetRequest(YEndpoints.Playlist, WebRequestMethods.Http.Post, query);
        }
    }
}