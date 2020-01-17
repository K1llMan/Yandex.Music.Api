using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Models.Artist
{
    public class YArtist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Various { get; set; }
        public bool Composer { get; set; }
        public YArtistCover Cover { get; set; }
        public List<string> Genres { get; set; }

        internal static YArtist FromJson(JToken json)
        {
            return new YArtist
            {
                Id = json["id"].ToObject<string>(),
                Name = json["name"].ToObject<string>(),
                Various = json["various"].ToObject<bool>(),
                Composer = json["composer"].ToObject<bool>(),
                Cover = YArtistCover.FromJson(json["cover"]),
                Genres = json["genres"].Select(x => x.ToObject<string>()).ToList()
            };
        }
    }
}