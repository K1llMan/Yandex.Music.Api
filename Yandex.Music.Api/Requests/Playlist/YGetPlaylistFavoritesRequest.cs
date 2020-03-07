using System.Collections.Generic;
using System.Net;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YGetPlaylistFavoritesRequest : YRequest
    {
        public YGetPlaylistFavoritesRequest(HttpContext context) : base(context)
        {
        }

        public HttpWebRequest Create(string login, string lang)
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                { "owner", login },
                { "lang", lang },
                { "filter", "tracks" },
                { "likeFilter", "favorite" },
                { "external-domain", "music.yandex.ru" },
                { "overembed", "false" },
                { "ncrnd", "0.7506943983987266" }
            };

            return GetRequest(YEndpoints.Library, query: query);
        }
    }
}