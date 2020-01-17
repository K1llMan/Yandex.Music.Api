using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Search.Track;

namespace Yandex.Music.Api.Models.Search.Artist
{
    public class YSearchArtistModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public YCover Cover { get; set; }
        public bool? Composer { get; set; }
        public bool? Various { get; set; }
        public YSearchArtistCounter Counts { get; set; }
        public List<string> Genres { get; set; }
        public bool? TicketsAvailable { get; set; }
        public List<YSearchTrackModel> PopularTracks { get; set; }
        public List<string> Regions { get; set; }
        
        internal static YSearchArtistModel FromJson(JToken json)
        {
            if (json == null)
            {
                return null;
            }

            return new YSearchArtistModel
            {
                Id = json.SelectToken("id")?.ToObject<string>(),
                Name = json.SelectToken("name")?.ToObject<string>(),
                Cover = YCover.FromJson(json.SelectToken("cover")),
                Composer = json.SelectToken("composer")?.ToObject<bool>(),
                Various = json.SelectToken("various")?.ToObject<bool>(),
                Counts = YSearchArtistCounter.FromJson(json.SelectToken("counts")),
                Genres = json.SelectToken("genres")?.Select(x => x.ToObject<string>()).ToList(),
                TicketsAvailable = json.SelectToken("ticketsAvailable")?.ToObject<bool>(),
                PopularTracks = json.SelectToken("popularTracks")?.Select(x => YSearchTrackModel.FromJson(x)).ToList(),
                Regions = json.SelectToken("regions")?.Select(x => x.ToObject<string>()).ToList()
            };
        }
    }
}