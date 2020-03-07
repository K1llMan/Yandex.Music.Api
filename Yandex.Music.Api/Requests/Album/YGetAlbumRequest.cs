using System.Collections.Generic;
using System.Net;

namespace Yandex.Music.Api.Requests.Album
{
    internal class YGetAlbumRequest : YRequest
    {
        public YGetAlbumRequest(HttpContext context) : base(context)
        {
        }

        public HttpWebRequest Create(string albumId, string lang)
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                { "album", albumId },
                { "lang", lang },
                { "external-domain", "music.yandex.ru" },
                { "overembed", "false" }
            };

            return GetRequest(YEndpoints.Album, query: query);
        }
    }
}