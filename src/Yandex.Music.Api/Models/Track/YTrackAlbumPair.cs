using System;
using System.Linq;

namespace Yandex.Music.Api.Models.Track
{
    public class YTrackAlbumPair : IEquatable<YTrackAlbumPair>
    {
        public string AlbumId { get; set; }
        public string Id { get; set; }

        public override string ToString()
        {
            return string.Join(":", new[] { Id, AlbumId }.Where(s => !string.IsNullOrEmpty(s)));
        }

        #region IEquatable

        public bool Equals(YTrackAlbumPair other)
        {
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Id, other.Id) && string.Equals(AlbumId, other.AlbumId);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((YTrackAlbumPair) obj);
        }

        public override int GetHashCode()
        {
            unchecked {
                return ((Id != null ? Id.GetHashCode() : 0) * 397) ^ (AlbumId != null ? AlbumId.GetHashCode() : 0);
            }
        }

        #endregion IEquatable
    }
}
