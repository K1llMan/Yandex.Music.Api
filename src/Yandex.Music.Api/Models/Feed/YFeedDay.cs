using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Yandex.Music.Api.Models.Feed.Event;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Models.Feed {
    public class YFeedDay
    {
        public DateTime Day { get; set; }
        [JsonConverter(typeof(YFeedEventConverter))]
        public List<YFeedEventTitled> Events { get; set; }
        public List<YTrack> TracksToPlay { get; set; }
        public List<YFeedDayTrackWithAds> TracksToPlayWithAds { get; set; }
    }
}