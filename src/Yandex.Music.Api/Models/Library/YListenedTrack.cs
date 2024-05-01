using System;
using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Models.Library
{
    public class YListenedTrack
    {
        public YTrackId TrackId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}