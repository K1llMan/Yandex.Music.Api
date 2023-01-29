using System.Collections.Generic;

using Yandex.Music.Api.Models.Artist;

namespace Yandex.Music.Api.Models.Feed.Event
{
    public class YFeedEventSimilarArtists: YFeedEventTitled
    {
        public YArtist SimilarToArtist { get; set; }
        public List<YArtist> SimilarArtists { get; set; }
    }
}