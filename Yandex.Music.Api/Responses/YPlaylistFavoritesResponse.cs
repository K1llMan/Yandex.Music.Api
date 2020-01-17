using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Responses
{
    public class YPlaylistFavoritesResponse
    {
        public bool Success { get; set; }
        public YCountsTracks CountsTracks { get; set; }
        public List<YTrack> Tracks { get; set; }
        public List<YTrackAlbumPair> ContestTracksIds { get; set; }
        public List<string> TrackIds { get; set; }
        public bool Verified { get; set; }
        public YOwner Owner { get; set; }
        public bool Visibility { get; set; }
        public List<YProfile> Profiles { get; set; }
        public YLikedCounts Counts { get; set; }
        public bool HasTracks { get; set; }
        public bool IsRadioAvailable { get; set; }

        internal static YPlaylistFavoritesResponse FromJson(JToken json)
        {
            return new YPlaylistFavoritesResponse
            {
                Success = json["success"].ToObject<bool>(),
                CountsTracks = YCountsTracks.FromJson(json["countsTracks"]),
                Tracks = json["tracks"].Select(YTrack.FromJson).ToList(),
                ContestTracksIds = json["contestTracksIds"].Select(x => YTrackAlbumPair.FromJson(x)).ToList(),
                TrackIds = json["trackIds"].Select(x => x.ToObject<string>()).ToList(),
                Verified = json["verified"].ToObject<bool>(),
                Owner = YOwner.FromJson(json["owner"]),
                Visibility = json["visibility"].ToObject<bool>(),
                Profiles = json["profiles"].Select(x => YProfile.FromJson(x)).ToList(),
                Counts = YLikedCounts.FromJson(json["counts"]),
                HasTracks = json["hasTracks"].ToObject<bool>(),
                IsRadioAvailable = json["isRadioAvailable"].ToObject<bool>()
            };
        }
    }
}