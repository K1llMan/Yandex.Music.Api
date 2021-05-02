using System.Collections.Generic;

using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Search.Album;
using Yandex.Music.Api.Models.Search.Artist;

namespace Yandex.Music.Api.Models.Search.Track
{
    public class YSearchTrackModel
    {
        #region Свойства

        public List<YSearchAlbumModel> Albums { get; set; }
        public List<YSearchArtist> Artists { get; set; }
        public bool Available { get; set; }
        public bool AvailableAsRbt { get; set; }
        public bool AvailableForPremiumUsers { get; set; }
        public string ContentWarning { get; set; }
        public string CoverUri { get; set; }
        public long DurationMs { get; set; }
        public bool Explicit { get; set; }
        public string Id { get; set; }
        public bool LyricsAvailable { get; set; }
        public List<string> Regions { get; set; }
        public bool RememberPosition { get; set; }
        public string StorageDir { get; set; }
        public string Title { get; set; }
        public YTrackSharingFlag TrackSharingFlag { get; set; }
        public YSearchTrackType Type { get; set; }
        public string Version { get; set; }

        #endregion
    }
}