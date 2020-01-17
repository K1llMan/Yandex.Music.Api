using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Common
{
    public class YLikedCounts
    {
        public long LikedArtists { get; set; }
        public long LikedAlbums { get; set; }

        internal static YLikedCounts FromJson(JToken json)
        {
            return new YLikedCounts
            {
                LikedArtists = json["likedArtists"].ToObject<long>(),
                LikedAlbums = json["likedAlbums"].ToObject<long>()
            };
        }
    }
}
