using System.Collections.Generic;

using Newtonsoft.Json;

using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Common.Cover;

namespace Yandex.Music.Api.Models.Search.Playlist
{
    public class YSearchPlaylistModel
    {
        public bool Available { get; set; }
        [JsonConverter(typeof(YCoverConverter))]
        public YCover Cover { get; set; }
        public string CoverUri { get; set; }
        public string Description { get; set; }
        public string DescriptionFormatted { get; set; }
        public string Kind { get; set; }
        public long LikesCount { get; set; }
        public YOwner Owner { get; set; }
        public string PlaylistUuid { get; set; }
        public List<string> Regions { get; set; }
        public int Revision { get; set; }
        public List<YTag> Tags { get; set; }
        public string Title { get; set; }
        public int TrackCount { get; set; }
        public string Uid { get; set; }
    }
}