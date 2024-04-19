using System;
using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Models.Track
{
    public class YListenedTrack
    {
        public YTrackId TrackId { get; set; }
        public string TimeStamp { get; set; }
    }
}