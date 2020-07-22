using System.Collections.Generic;

using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Models.Playlist
{
    public class YPlaylist
    {
        #region Поля

        public YPlaylistUidPair GetKey()
        {
            return new YPlaylistUidPair {
                Uid = Owner.Uid,
                Kind = Kind
            };
        }

        #endregion

        #region Свойства

        public string BackgroundColor { get; set; }
        public bool Collective { get; set; }
        public YPlaylistCover Cover { get; set; }
        public string Description { get; set; }
        public string DescriptionFormatted { get; set; }
        public bool DoNotIndex { get; set; }
        public long DurationMs { get; set; }
        public YGeneratedPlaylistType GeneratedPlaylistType { get; set; }
        public string IdForFrom { get; set; }
        public string Image { get; set; }
        public bool IsBanner { get; set; }
        public bool IsPremiere { get; set; }
        public string Kind { get; set; }
        public int LikesCount { get; set; }
        public YPlaylistMadeFor MadeFor { get; set; }
        public string Modified { get; set; }
        public string OgImage { get; set; }
        public string OgTitle { get; set; }
        public YOwner Owner { get; set; }
        public YPlaylistPlayCounter PlayCounter { get; set; }
        public List<YPlaylistPrerolls> Prerolls { get; set; }
        public int Revision { get; set; }
        public List<YTag> Tags { get; set; }
        public string TextColor { get; set; }
        public string Title { get; set; }
        public int TrackCount { get; set; }
        public List<int> TrackIds { get; set; }
        public List<YTrackContainer> Tracks { get; set; }
        public string Uid { get; set; }
        public string UrlPart { get; set; }
        public string Visibility { get; set; }

        #endregion
    }
}