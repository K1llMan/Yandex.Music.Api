using System.Collections.Generic;

using Newtonsoft.Json;

using Yandex.Music.Api.Common.YTrack;

namespace Yandex.Music.Api.Common.YPlaylist
{
    public class YPlaylistChange
    {
        [JsonProperty("op")]
        public YPlaylistChangeType Operation { get; set; }

        public int? At { get; set; }

        public int? From { get; set; }

        public int? To { get; set; }

        public List<YTrackAlbumPair> Tracks { get; set; }
    }
}
