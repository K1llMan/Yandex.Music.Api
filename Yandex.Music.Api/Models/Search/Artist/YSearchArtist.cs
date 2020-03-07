using System.Collections.Generic;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Models.Search.Artist
{
    public class YSearchArtist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public YCover Cover { get; set; }
        public bool? Composer { get; set; }
        public bool? Various { get; set; }
        public List<string> Decomposed { get; set; }
    }
}