using System.Collections.Generic;

using Yandex.Music.Api.Models.Artist;

namespace Yandex.Music.Api.Models.Feed.Event
{
    public class YArtistsFromHistory
    {
        public YArtist Artist { get; set; }
        public List<YArtist> ArtistsFromHistory { get; set; }
    }
}