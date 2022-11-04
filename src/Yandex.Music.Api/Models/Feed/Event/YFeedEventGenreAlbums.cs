using System.Collections.Generic;

using Yandex.Music.Api.Models.Album;

namespace Yandex.Music.Api.Models.Feed.Event
{
    public class YFeedEventGenreAlbums: YFeedEvent
    {
        public string Genre { get; set; }
        public List<YAlbum> Albums { get; set; }
    }
}