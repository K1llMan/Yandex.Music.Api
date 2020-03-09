using System.Collections.Generic;

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
    }
}