using System;

namespace Yandex.Music.Api.Common.YTrack
{
    public class YTrackAlbumPair: IEquatable<YTrackAlbumPair>
    {
        public string Id { get; set; }
        public string AlbumId { get; set; }

        public override string ToString()
        {
            return $"{Id}:{AlbumId}";
        }

        #region IEquatable

        public bool Equals(YTrackAlbumPair other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Id, other.Id) && string.Equals(AlbumId, other.AlbumId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((YTrackAlbumPair)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Id != null ? Id.GetHashCode() : 0) * 397) ^ (AlbumId != null ? AlbumId.GetHashCode() : 0);
            }
        }

        #endregion IEquatable
    }
}