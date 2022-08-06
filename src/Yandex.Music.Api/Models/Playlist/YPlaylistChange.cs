using System.Collections.Generic;

using Newtonsoft.Json;

using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Models.Playlist
{
    public class YPlaylistChange
    {
        public int? At { get; set; }
        public int? From { get; set; }
        [JsonProperty("op")] 
        public YPlaylistChangeType Operation { get; set; }
        public int? To { get; set; }
        public List<YTrackAlbumPair> Tracks { get; set; }
    }
}