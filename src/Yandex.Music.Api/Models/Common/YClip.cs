using System.Collections.Generic;

using Yandex.Music.Api.Models.Artist;

namespace Yandex.Music.Api.Models.Common
{
    public class YClip
    {
        public List<YArtist> Artists { get; set; }
        public string ClipId { get; set; }
        public List<string> Disclaimers { get; set; }
        public int Duration { get; set; }
        public bool Explicit { get; set; }
        public string PlayerId { get; set; }
        public string PreviewUrl { get; set; }
        public string Uuid { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public List<string> TrackIds { get; set; }
    }
}