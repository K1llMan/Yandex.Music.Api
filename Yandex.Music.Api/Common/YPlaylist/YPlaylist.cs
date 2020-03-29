using System.Collections.Generic;

using Yandex.Music.Api.Common.YTrack;
using Yandex.Music.Api.Models.Playlist;

namespace Yandex.Music.Api.Common.YPlaylist
{
    public class YPlaylist
    {
        public int? Revision { get; set; }
        public string Kind { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DescriptionFormatted { get; set; }
        public int? TrackCount { get; set; }
        public string Visibility { get; set; }
        public YPlaylistCover Cover { get; set; }
        public YOwner Owner { get; set; }
        public List<YTrackContainer> Tracks { get; set; }
        public string Modified { get; set; }
        public List<int> TrackIds { get; set; }
        public string OgImage { get; set; }
        public List<YTag> Tags { get; set; }
        public int? LikesCount { get; set; }
        public long? Duration { get; set; }
        public bool? Collective { get; set; }
        public List<YPlaylistPrerolls> Prerolls { get; set; }
        public YPlaylistPlayCounter PlayCounter { get; set; }
        public string IdForFrom { get; set; }
        public YGeneratedPlaylistType GeneratedPlaylistType { get; set; }
        public string UrlPart { get; set; }
        public YPlaylistMadeFor MadeFor { get; set; }
        public string OgTitle { get; set; }
        public bool? DoNotIndex { get; set; }

        public YPlaylistUidPair GetKey()
        {
            return new YPlaylistUidPair {
                Uid = Owner.Uid,
                Kind = Kind
            };
        }
    }
}