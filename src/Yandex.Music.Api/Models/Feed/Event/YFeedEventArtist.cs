using Yandex.Music.Api.Models.Artist;

namespace Yandex.Music.Api.Models.Feed.Event
{
    public class YFeedEventArtist: YFeedEventTracks
    {
        public YArtist Artist { get; set; }
    }
}