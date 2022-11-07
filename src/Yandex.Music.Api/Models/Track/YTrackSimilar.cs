using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Track
{
    public class YTrackSimilar
    {
        public YTrack Track { get; set; }
        public List<YTrack> SimilarTracks { get; set; }
    }
}