using System.Collections;
using System.Collections.Generic;

using Newtonsoft.Json;

using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Models.Track
{
    public class YTracksContainer: YBaseModel
    {
        [JsonProperty("pager")]
        public YPager Pager { get; set; }
        
        [JsonProperty("tracks")]
        public List<YTrack> Tracks { get; set; }
    }
}