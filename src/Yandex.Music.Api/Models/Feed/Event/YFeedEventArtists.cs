using System.Collections.Generic;

using Yandex.Music.Api.Models.Artist;

namespace Yandex.Music.Api.Models.Feed.Event
{
    public class YFeedEventArtists: YFeedEventTitled
    {
        public List<YArtist> Artists { get; set; }
    }
}