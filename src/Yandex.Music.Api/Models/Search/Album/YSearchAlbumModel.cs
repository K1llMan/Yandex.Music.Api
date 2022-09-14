using System.Collections.Generic;

using Yandex.Music.Api.Models.Album;

namespace Yandex.Music.Api.Models.Search.Album
{
    public class YSearchAlbumModel: YAlbum
    {
        public List<string> AvailableRegions { get; set; }
        public new List<string> Labels { get; set; }
        public int OriginalReleaseYear { get; set; }
        public List<string> Regions { get; set; }
    }
}