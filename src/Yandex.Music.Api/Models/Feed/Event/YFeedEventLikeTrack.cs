using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Models.Feed.Event
{
    public class YFeedEventLikeTrack: YFeedEventTracks
    {
        public YTrack LikedTrack { get; set; }
    }
}