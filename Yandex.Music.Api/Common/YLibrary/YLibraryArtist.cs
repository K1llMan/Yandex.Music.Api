using System.Collections.Generic;

using Yandex.Music.Api.Models.Artist;

namespace Yandex.Music.Api.Common.YLibrary
{
    public class YLibraryArtist: YArtist
    {
        public YArtistCounts Counts { get; set; }
        public bool Available { get; set; }
        public YArtistRatings Ratings { get; set; }
        public List<YLink> Links { get; set; }
        public bool TicketsAvailable { get; set; }
    }
}
