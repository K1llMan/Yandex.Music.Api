using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Feed.Event
{
    public class YFeedEventArtistWithArtists: YFeedEvent
    {
        public List<YArtistsFromHistory> ArtistsWithArtistsFromHistory { get; set; }
    }
}