using System.Collections.Generic;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Responses
{
    public class YAlbumResponse
    {
        public List<YArtistResponse> Artists { get; set; }
        public bool? Available { get; set; }
        public bool? AvailableForPremiumUsers { get; set; }
        public string CoverUri { get; set; }
        public string Genre { get; set; }
        public string Id { get; set; }
        public string OriginalReleaseYear { get; set; }
        public List<string> Regions { get; set; }
        public string StorageDir { get; set; }
        public string Title { get; set; }
        public int? TrackCount { get; set; }
        public string Year { get; set; }
        public List<string> Bests { get; set; }
        public string Type { get; set; }
        public List<List<YTrack>> Volumes { get; set; }
    }
}