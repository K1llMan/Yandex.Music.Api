using System.Collections.Generic;

using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Models.Library
{
    public class YRecentlyListenedContext
    {
        public List<YRecentlyListened> Contexts { get; set; }
        public List<YTrack> OtherTracks { get; set; }
    }
}
