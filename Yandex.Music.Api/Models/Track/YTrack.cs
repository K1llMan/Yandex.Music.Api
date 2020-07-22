using System;
using System.Collections.Generic;
using System.Linq;

using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Models.Track
{
    public class YTrack : IEquatable<YTrack>
    {
        #region Поля

        public YTrackAlbumPair GetKey()
        {
            return new YTrackAlbumPair {
                Id = Id,
                AlbumId = Albums?.FirstOrDefault()?.Id
            };
        }

        #endregion

        #region Свойства

        public List<YAlbum> Albums { get; set; }
        public List<YArtist> Artists { get; set; }
        public bool Available { get; set; }
        public bool AvailableForPremiumUsers { get; set; }
        public bool AvailableFullWithoutPermission { get; set; }
        public bool Best { get; set; }
        public string ContentWarning { get; set; }
        public string CoverUri { get; set; }
        public long DurationMs { get; set; }
        public string Error { get; set; }
        public long FileSize { get; set; }
        public string Id { get; set; }
        public bool LyricsAvailable { get; set; }
        public YMajor Major { get; set; }
        public YTrackNormalization Normalization { get; set; }
        public string OgImage { get; set; }
        public long? PreviewDurationMs { get; set; }
        public string RealId { get; set; }
        public bool RememberPosition { get; set; }
        public string StorageDir { get; set; }
        public YTrack Substituted { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Version { get; set; }

        #endregion

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
            if (obj.GetType() != GetType()) return false;
            return Equals((YTrack) obj);
        }

        public override int GetHashCode()
        {
            return GetKey().GetHashCode();
        }

        #endregion IEquatable
    }
}