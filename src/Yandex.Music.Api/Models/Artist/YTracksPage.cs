using System.Collections.Generic;

using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Models.Artist
{
    public class YTracksPage
    {
        public YPager Pager { get; set; }

        public List<YTrack> Tracks { get; set; }
    }
}