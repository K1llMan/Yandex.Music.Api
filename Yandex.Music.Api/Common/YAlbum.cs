using System.Collections.Generic;

using Yandex.Music.Api.Models.Artist;

namespace Yandex.Music.Api.Common
{
    public class YAlbum
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ContentWarning { get; set; }
        public int Year { get; set; }
        public string ReleaseDate { get; set; }
        public string CoverUri { get; set; }
        public string OgImage { get; set; }

        public string Genre { get; set; }

//            public List<string> Buy { get; set; }
        public int TrackCount { get; set; }
        public bool Recent { get; set; }
        public bool VeryImportant { get; set; }
        public List<YArtist> Artists { get; set; }
        public List<YLabel> Labels { get; set; }
        public bool Available { get; set; }
        public bool AvailableForPremiumUsers { get; set; }
        public bool AvailableForMobile { get; set; }
        public bool AvailablePartially { get; set; }
        public List<string> Bests { get; set; }
        public YTrackPosition TrackPosition { get; set; }
    }
}