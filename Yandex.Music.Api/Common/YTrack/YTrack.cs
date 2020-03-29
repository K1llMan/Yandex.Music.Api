using System;
using System.Collections.Generic;
using System.Linq;

using Yandex.Music.Api.Models.Artist;

namespace Yandex.Music.Api.Common.YTrack
{
    public class YTrack: IEquatable<YTrack>
    {
        public string Id { get; set; }
        public string RealId { get; set; }
        public string Title { get; set; }
        public YMajor Major { get; set; }
        public bool? Available { get; set; }
        public bool? AvailableForPremiumUsers { get; set; }
        public bool? AvailableFullWithoutPermission { get; set; }
        public long? DurationMs { get; set; }
        public string StorageDir { get; set; }
        public long? FileSize { get; set; }
        public YTrackNormalization Normalization { get; set; }
        public long? PreviewDurationMs { get; set; }
        public List<YArtist> Artists { get; set; }
        public List<YAlbum> Albums { get; set; }
        public string CoverUri { get; set; }
        public string OgImage { get; set; }
        public bool? LyricsAvailable { get; set; }
        public string Type { get; set; }
        public bool? RememberPosition { get; set; }

        public YTrackAlbumPair GetKey()
        {
            return new YTrackAlbumPair {
                Id = Id,
                AlbumId = Albums?.FirstOrDefault()?.Id
            };
        }

        #region IEquatable

        public bool Equals(YTrack other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return GetKey().Equals(other.GetKey());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((YTrack) obj);
        }

        public override int GetHashCode()
        {
            return GetKey().GetHashCode();
        }

        #endregion IEquatable
    }
}