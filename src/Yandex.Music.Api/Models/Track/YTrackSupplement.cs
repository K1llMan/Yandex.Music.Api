using System.Collections.Generic;

using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Models.Track
{
    public class YTrackSupplement
    {
        public string Id { get; set; }
        public List<YClip> Clips { get; set; }
        public YLyrics Lyrics { get; set; }
        public List<YVideo> Videos { get; set; }
    }
}