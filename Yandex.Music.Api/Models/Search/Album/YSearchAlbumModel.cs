using System.Collections.Generic;

using Yandex.Music.Api.Models.Search.Artist;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Models.Search.Album
{
    public class YSearchAlbumModel
    {
        #region Свойства

        public List<YSearchArtist> Artists { get; set; }
        public bool Available { get; set; }
        public bool AvailableForPremiumUsers { get; set; }
        public List<string> AvailableRegions { get; set; }
        public string ContentWarning { get; set; }
        public string CoverUri { get; set; }
        public string Genre { get; set; }
        public string Id { get; set; }
        public List<string> Labels { get; set; }
        public int LikesCount { get; set; }
        public int OriginalReleaseYear { get; set; }
        public List<string> Regions { get; set; }
        public string StorageDir { get; set; }
        public string Title { get; set; }
        public int TrackCount { get; set; }
        public YTrackPosition TrackPosition { get; set; }
        public string Type { get; set; }
        public string Version { get; set; }
        public int Year { get; set; }

        #endregion
    }
}