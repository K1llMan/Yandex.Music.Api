namespace Yandex.Music.Api.Models.Feed.Event
{
    public class YFeedEventTitle
    {
        public string Id { get; set; }
        public YFeedEventTitleType Type { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}