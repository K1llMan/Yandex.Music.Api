using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Models.Radio
{
    public class YSequenceItem
    {
        public bool Liked { get; set; }
        public YTrack Track { get; set; }
        public YTrackParameters TrackParameters { get; set; }
        public string Type { get; set; }
    }
}
