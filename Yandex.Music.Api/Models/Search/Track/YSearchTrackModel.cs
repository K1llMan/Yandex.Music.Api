using System.Collections.Generic;

using Yandex.Music.Api.Models.Search.Album;
using Yandex.Music.Api.Models.Search.Artist;

namespace Yandex.Music.Api.Models.Search.Track
{
    public class YSearchTrackModel
    {
        public string Id { get; set; }
        public bool? Available { get; set; }
        public bool? AvailableAsRbt { get; set; }
        public bool? AvailableForPremiumUsers { get; set; }
        public bool? LyricsAvailable { get; set; }
        public bool? RememberPosition { get; set; }
        public List<YSearchAlbumModel> Albums { get; set; }
        public string StorageDir { get; set; }
        public long? DurationMs { get; set; }
        public bool? Explicit { get; set; }
        public string Title { get; set; }
        public List<YSearchArtist> Artists { get; set; }
        public List<string> Regions { get; set; }
    }
}