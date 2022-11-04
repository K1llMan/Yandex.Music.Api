using System.Collections.Generic;

using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Models.Feed.Event
{
    public class YFeedEventTracks: YFeedEvent
    {
        public List<YTrack> Tracks { get; set; }
    }
}