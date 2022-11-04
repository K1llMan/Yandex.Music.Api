namespace Yandex.Music.Api.Models.Feed.Event
{
    public class YFeedEventSimilarGenre: YFeedEventTracks
    {
        public string SimilarToGenre { get; set; }
        public string SimilarGenre { get; set; }
    }
}