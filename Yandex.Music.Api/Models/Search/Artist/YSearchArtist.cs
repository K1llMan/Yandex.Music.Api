using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Models.Search.Artist
{
    public class YSearchArtist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public YCover Cover { get; set; }
        public bool? Composer { get; set; }
        public bool? Various { get; set; }
        public List<string> Decomposed { get; set; }
        
        internal static YSearchArtist FromJson(JToken json)
        {
            if (json == null)
            {
                return null;
            }

            return new YSearchArtist
            {
                Id = json.SelectToken("id")?.ToObject<string>(),
                Name = json.SelectToken("name")?.ToObject<string>(),
                Cover = YCover.FromJson(json.SelectToken("cover")),
                Composer = json.SelectToken("composer")?.ToObject<bool>(),
                Various = json.SelectToken("various")?.ToObject<bool>(),
                Decomposed = json.SelectToken("decomposed")?.Select(x => x.ToObject<string>()).ToList()
            };
        }
    }
}