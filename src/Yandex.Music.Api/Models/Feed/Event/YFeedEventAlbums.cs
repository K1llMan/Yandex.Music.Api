using System.Collections.Generic;

using Yandex.Music.Api.Models.Album;

namespace Yandex.Music.Api.Models.Feed.Event
{
    public class YFeedEventAlbums: YFeedEvent
    {
        public List<YAlbum> Albums { get; set; }
    }
}