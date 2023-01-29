using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Feed.Event
{
    public class YFeedEventTitled: YFeedEvent
    {
        public List<YFeedEventTitle> Title { get; set; }
        public YFeedEventType TypeForFrom { get; set; }
    }
}