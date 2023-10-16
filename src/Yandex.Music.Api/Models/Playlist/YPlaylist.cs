using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Common.Cover;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Models.Playlist
{
    public class YPlaylist : YBaseModel
    {
        #region Поля

        public YPlaylistUidPair GetKey()
        {
            return new YPlaylistUidPair {
                Uid = Owner.Uid,
                Kind = Kind
            };
        }

        #endregion Поля

        #region Свойства

        public YButton ActionButton { get; set; }
        public string AnimatedCoverUri { get; set; }
        public bool Available { get; set; }
        public string BackgroundColor { get; set; }
        public string BackgroundImageUrl { get; set; }
        public string BackgroundVideoUrl { get; set; }
        public bool Collective { get; set; }
        [JsonConverter(typeof(YCoverConverter))]
        public YCover Cover { get; set; }
        [JsonConverter(typeof(YCoverConverter))]
        public YCover CoverWithoutText { get; set; }
        public YCustomWave CustomWave { get; set; }
        public List<YId> RecentTracks { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string DescriptionFormatted { get; set; }
        public bool DoNotIndex { get; set; }
        public long DurationMs { get; set; }
        public bool EverPlayed { get; set; }
        public string GeneratedPlaylistType { get; set; }
        public string IdForFrom { get; set; }
        public string Image { get; set; }
        public bool IsBanner { get; set; }
        public bool IsPremiere { get; set; }
        public string Kind { get; set; }
        public List<YPlaylist> LastOwnerPlaylists { get; set; }
        public int LikesCount { get; set; }
        public YPlaylistMadeFor MadeFor { get; set; }
        public string MetrikaId { get; set; }
        public string Modified { get; set; }
        public string OgImage { get; set; }
        public string OgTitle { get; set; }
        public string OgDescription { get; set; }
        public YOwner Owner { get; set; }
        public YPager Pager { get; set; }
        public YPlaylistPlayCounter PlayCounter { get; set; }
        public string PlaylistUuid { get; set; }
        public List<YPrerolls> Prerolls { get; set; }
        public int Revision { get; set; }
        public List<YPlaylist> SimilarPlaylists { get; set; }
        public int Snapshot { get; set; }
        public List<YTag> Tags { get; set; }
        public string TextColor { get; set; }
        public string Title { get; set; }
        public int TrackCount { get; set; }
        public List<string> TrackIds { get; set; }
        public List<YTrackContainer> Tracks { get; set; }
        public string Uid { get; set; }
        public string UrlPart { get; set; }
        public string Visibility { get; set; }

        #endregion Свойства
    }
}