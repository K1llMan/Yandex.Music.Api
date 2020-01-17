using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Search.Album;
using Yandex.Music.Api.Models.Search.Artist;

namespace Yandex.Music.Api.Models.Search.Track
{
    public class YSearchTrackModel
    {
        public string Id { get; set; }
        public bool? Available { get; set; }
        public bool? AvailableAsRbt { get; set; }
        public bool? AvailableForPremiumUsers { get; set; }
        public bool? LyricsAvailable { get; set; }
        public bool? RememberPosition { get; set; }
        public List<YSearchAlbumModel> Albums { get; set; }
        public string StorageDir { get; set; }
        public long? DurationMs { get; set; }
        public bool? Explicit { get; set; }
        public string Title { get; set; }
        public List<YSearchArtist> Artists { get; set; }
        public List<string> Regions { get; set; }

        internal static YSearchTrackModel FromJson(JToken json)
        {
            if (json == null)
            {
                return null;
            }

            return new YSearchTrackModel
            {
                Id = json.SelectToken("id")?.ToObject<string>(),
                Available = json.SelectToken("available")?.ToObject<bool>(),
                AvailableAsRbt = json.SelectToken("availableAsRbt")?.ToObject<bool>(),
                AvailableForPremiumUsers = json.SelectToken("availableForPremiumUsers")?.ToObject<bool>(),
                LyricsAvailable = json.SelectToken("lyricsAvailable")?.ToObject<bool>(),
                RememberPosition = json.SelectToken("rememberPosition")?.ToObject<bool>(),
                Albums = json.SelectToken("albums")?.Select(x => YSearchAlbumModel.FromJson(x)).ToList(),
                StorageDir = json.SelectToken("storageDir")?.ToObject<string>(),
                DurationMs = json.SelectToken("durationMs")?.ToObject<long>(),
                Explicit = json.SelectToken("explicit")?.ToObject<bool>(),
                Title = json.SelectToken("title")?.ToObject<string>(),
                Artists = json.SelectToken("artists")?.Select(x => YSearchArtist.FromJson(x)).ToList(),
                Regions = json.SelectToken("regions")?.Select(x => x.ToObject<string>()).ToList()
            };
        }
    }
}