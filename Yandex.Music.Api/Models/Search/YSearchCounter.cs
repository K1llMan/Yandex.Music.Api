using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Models.Search
{
    public class YSearchCounter
    {
        public long? Artists { get; set; }
        public long? Albums { get; set; }
        public long? Tracks { get; set; }
        public long? Videos { get; set; }
        public long? Playlists { get; set; }
        public long? Users { get; set; }

        internal static YSearchCounter FromJson(JToken json)
        {
            if (json == null)
            {
                return null;
            }

            return new YSearchCounter
            {
                Artists = json.SelectToken("artists")?.ToObject<long>(),
                Albums = json.SelectToken("albums")?.ToObject<long>(),
                Tracks = json.SelectToken("tracks")?.ToObject<long>(),
                Videos = json.SelectToken("videos")?.ToObject<long>(),
                Playlists = json.SelectToken("playlists")?.ToObject<long>(),
                Users = json.SelectToken("users")?.ToObject<long>()
            };
        }
    }
}