using System.Collections.Generic;

using Yandex.Music.Api.Models.Search.Album;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Models.Search.Track
{
    public class YSearchTrackModel: YTrack
    {
        public new List<YSearchAlbumModel> Albums { get; set; }
        public bool AvailableAsRbt { get; set; }
        public bool Explicit { get; set; }
        public List<string> Regions { get; set; }
    }
}