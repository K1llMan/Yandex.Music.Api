using System.Collections.Generic;

using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Models.Library
{
    public class YLibraryArtist : YArtist
    {
        public bool Available { get; set; }
        public YArtistCounts Counts { get; set; }
        public List<YLink> Links { get; set; }
        public YArtistRatings Ratings { get; set; }
        public bool TicketsAvailable { get; set; }
    }
}