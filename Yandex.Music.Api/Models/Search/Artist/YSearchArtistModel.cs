using System.Collections.Generic;

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
    }
}