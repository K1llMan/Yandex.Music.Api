using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Search.Artist;

namespace Yandex.Music.Api.Models.Search.Album
{
    public class YSearchAlbumModel
    {
        public string Id { get; set; }
        public string StorageDir { get; set; }
        public int? OriginalReleaseYear { get; set; }
        public int? Year { get; set; }
        public List<YSearchArtist> Artists { get; set; }
        public string CoverUri { get; set; }
        public int? TrackCount { get; set; }
        public string Genre { get; set; }
        public bool? Available { get; set; }
        public bool? AvailableForPremiumUsers { get; set; }
        public string Title { get; set; }
        public YTrackPosition TrackPosition { get; set; }
        public string Type { get; set; }
        public List<string> Regions { get; set; }

        internal static YSearchAlbumModel FromJson(JToken json)
        {
            if (json == null)
            {
                return null;
            }

            return new YSearchAlbumModel
            {
                Id = json.SelectToken("id")?.ToObject<string>(),
                StorageDir = json.SelectToken("storageDir")?.ToObject<string>(),
                OriginalReleaseYear = json.SelectToken("originalReleaseYear")?.ToObject<int>(),
                Year = json.SelectToken("year")?.ToObject<int>(),
                Artists = json.SelectToken("artists")?.Select(x => YSearchArtist.FromJson(x)).ToList(),
                CoverUri = json.SelectToken("coverUri")?.ToObject<string>(),
                TrackCount = json.SelectToken("trackCount")?.ToObject<int>(),
                Genre = json.SelectToken("genre")?.ToObject<string>(),
                Available = json.SelectToken("available")?.ToObject<bool>(),
                AvailableForPremiumUsers = json.SelectToken("availableForPremiumUsers")?.ToObject<bool>(),
                Title = json.SelectToken("title")?.ToObject<string>(),
                TrackPosition = YTrackPosition.FromJson(json.SelectToken("trackPosition")),
                Type = json.SelectToken("type")?.ToObject<string>(),
                Regions = json.SelectToken("regions")?.Select(x => x.ToObject<string>()).ToList(),
            };
        }
    }
}