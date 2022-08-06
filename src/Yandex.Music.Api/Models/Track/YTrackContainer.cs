using System;

namespace Yandex.Music.Api.Models.Track
{
    public class YTrackContainer : IEquatable<YTrackContainer>
    {
        public string Id { get; set; }
        public decimal OriginalIndex { get; set; }
        public bool Recent { get; set; }
        public DateTime Timestamp { get; set; }
        public YTrack Track { get; set; }

        #region IEquatable

        public bool Equals(YTrackContainer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Track.GetKey() == other.Track.GetKey();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((YTrackContainer) obj);
        }

        public override int GetHashCode()
        {
            return Track != null ? Track.GetHashCode() : 0;
        }

        #endregion IEquatable
    }
}