using System.Collections.Generic;
using Yandex.Music.Api.Models.Album;
using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Models.Label
{
    public class YLabelAlbums
    {
        public YPager Pager { get; set; }
        public List<YAlbum> Albums { get; set; }
    }
}