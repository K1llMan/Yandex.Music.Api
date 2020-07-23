using System.Collections.Generic;

using Newtonsoft.Json;

using Yandex.Music.Api.Models.Common.Cover;
using Yandex.Music.Api.Models.Search.Track;

namespace Yandex.Music.Api.Models.Search.Artist
{
    public class YSearchArtistModel
    {
        public bool Composer { get; set; }
        public YSearchArtistCounter Counts { get; set; }

        [JsonConverter(typeof(YCoverConverter))]
        public YCover Cover { get; set; }

        public List<string> Genres { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public List<YSearchTrackModel> PopularTracks { get; set; }
        public List<string> Regions { get; set; }
        public bool TicketsAvailable { get; set; }
        public bool Various { get; set; }
    }
}