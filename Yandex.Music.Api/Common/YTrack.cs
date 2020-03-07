using System.Collections.Generic;
using System.Linq;
using Yandex.Music.Api.Models.Artist;

namespace Yandex.Music.Api.Common
{
    public class YTrack
    {
        public string Id { get; set; }
        public string RealId { get; set; }
        public string Title { get; set; }
        public YMajor Major { get; set; }
        public bool? Available { get; set; }
        public bool? AvailableForPremiumUsers { get; set; }
        public bool? AvailableFulWithoutPermission { get; set; }
        public long? DurationMs { get; set; }
        public string StorageDir { get; set; }
        public long? FileSize { get; set; }
        public YTrackNormalization Normalization { get; set; }
        private long? PreviewDurationMs { get; set; }
        public List<YArtist> Artists { get; set; }
        public List<YAlbum> Albums { get; set; }
        public string CoverUri { get; set; }
        public string OgImage { get; set; }
        public bool? LyricsAvailable { get; set; }
        public string Type { get; set; }
        public bool? RememberPosition { get; set; }
        public bool? EmbedPlayback { get; set; }
        public string Prefix { get; set; }

        public string GetKey()
        {
            return $"{Id}:{Albums.FirstOrDefault().Id}";
        }
    }
}