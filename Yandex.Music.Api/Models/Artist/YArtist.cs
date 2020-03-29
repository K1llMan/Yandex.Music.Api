using System.Collections.Generic;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Models.Artist
{
    public class YArtist
    {
        public bool Available { get; set; }
        public bool Composer { get; set; }
        public YArtistCounts Counts { get; set; }
        public YArtistCover Cover { get; set; }
        public List<string> DbAliases { get; set; }
        public string InitDate { get; set; }
        public string EndDate { get; set; }
        public string EnWikipediaLink { get; set; }
        public List<string> Genres { get; set; }
        public string Id { get; set; }
        public int LikesCount { get; set; }
        public List<YLink> Links { get; set; }
        public string Name { get; set; }
        public string OgImage { get; set; }
        public YArtistRatings Ratings { get; set; }
        public bool TicketsAvailable { get; set; }
        public bool Various { get; set; }
    }
}