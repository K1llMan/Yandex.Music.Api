using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Models.Search.Artist
{
    public class YSearchArtistCounter
    {
        public int? Tracks { get; set; }
        public int? DirectAlbums { get; set; }
        public int? AlsoAlbums { get; set; }
        public int? AlsoTracks { get; set; }

        internal static YSearchArtistCounter FromJson(JToken json)
        {
            if (json == null)
            {
                return null;
            }

            return new YSearchArtistCounter
            {
                Tracks = json.SelectToken("tracks")?.ToObject<int>(),
                DirectAlbums = json.SelectToken("directAlbums")?.ToObject<int>(),
                AlsoAlbums = json.SelectToken("alsoAlbums")?.ToObject<int>(),
                AlsoTracks = json.SelectToken("alsoTracks")?.ToObject<int>()
            };
        }
    }
}