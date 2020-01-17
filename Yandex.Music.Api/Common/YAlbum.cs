using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Responses;

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

        internal static YAlbum FromJson(JToken json)
        {
            if (json == null)
            {
                return null;
            }

            return new YAlbum
            {
                Id = json.SelectToken("id")?.ToObject<string>(),
                Title = json.SelectToken("title")?.ToObject<string>(),
                Year = json.SelectToken("year").ToObject<int>(),
                ReleaseDate = json.SelectToken("releaseDate")?.ToObject<string>(),
                CoverUri = json.SelectToken("coverUri")?.ToObject<string>(),
                OgImage = json.SelectToken("ogImage")?.ToObject<string>(),
                Genre = json.SelectToken("genre")?.ToObject<string>(),
//                Buy
                TrackCount = json.SelectToken("trackCount").ToObject<int>(),
                Recent = json.SelectToken("recent").ToObject<bool>(),
                VeryImportant = json.SelectToken("veryImportant").ToObject<bool>(),
                Artists = json.SelectToken("artists")?.Select(YArtist.FromJson).ToList(),
                Labels = json.SelectToken("labels")?.Select(YLabel.FromJson).ToList(),
                Available = json.SelectToken("available").ToObject<bool>(),
                AvailableForPremiumUsers = json.SelectToken("availableForPremiumUsers").ToObject<bool>(),
                AvailableForMobile = json.SelectToken("availableForMobile").ToObject<bool>(),
                AvailablePartially = json.SelectToken("availablePartially").ToObject<bool>(),
                Bests = json.SelectToken("bests")?.Select(x => x.ToObject<string>()).ToList(),
                TrackPosition = YTrackPosition.FromJson(json.SelectToken("trackPosition"))
            };
        }
    }
}
