using System.Collections.Generic;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Models.Label
{
    public class YLabelArtists
    {
        public YPager Pager { get; set; }
        public List<YArtist> Artists { get; set; }
    }
}
