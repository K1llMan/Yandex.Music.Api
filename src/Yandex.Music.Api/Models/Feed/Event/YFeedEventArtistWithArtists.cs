using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Feed.Event
{
    public class YFeedEventArtistWithArtists: YFeedEventTitled
    {
        public List<YArtistsFromHistory> ArtistsWithArtistsFromHistory { get; set; }
    }
}