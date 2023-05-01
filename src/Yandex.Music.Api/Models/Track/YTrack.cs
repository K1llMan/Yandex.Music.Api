using System;
using System.Collections.Generic;
using System.Linq;

using Yandex.Music.Api.Models.Album;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Models.Track
{
    public class YTrack : YBaseModel, IEquatable<YTrack>
    {
        public List<YAlbum> Albums { get; set; }
        public List<YArtist> Artists { get; set; }
        public bool Available { get; set; }
        public bool AvailableForPremiumUsers { get; set; }
        public bool AvailableFullWithoutPermission { get; set; }
        public List<string> AvailableForOptions { get; set; }
        public string BackgroundVideoUri { get; set; }
        public bool Best { get; set; }
        public string ContentWarning { get; set; }
        public string CoverUri { get; set; }
        public List<string> ClipIds { get; set; }
        public long DurationMs { get; set; }
        public string Error { get; set; }
        public YTrackFade Fade { get; set; }
        public long FileSize { get; set; }
        public string Id { get; set; }
        public bool IsSuitableForChildren { get; set; }
        public YMajor Major { get; set; }
        public YTrackNormalization Normalization { get; set; }
        public YTrackNormalizationR128 R128 { get; set; }
        public string OgImage { get; set; }
        public bool LyricsAvailable { get; set; }
        public YLyricsInfo LyricsInfo { get; set; }
        public string PlayerId { get; set; }
        public long PreviewDurationMs { get; set; }
        public YPodcastEpisodeType PodcastEpisodeType { get; set; }
        public DateTime PubDate { get; set; }
        public string RealId { get; set; }
        public bool RememberPosition { get; set; }
        public string ShortDescription { get; set; }
        public string StorageDir { get; set; }
        public YTrack Substituted { get; set; }
        public string Title { get; set; }
        public YTrackSharingFlag TrackSharingFlag { get; set; }
        public YTrackSource TrackSource { get; set; }
        public string Type { get; set; }
        public string Version { get; set; }

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