using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Responses
{
    public class YLibraryHistoryResponse
    {
        public bool Success { get; set; }
        public string BookmarksPlaylistsIds { get; set; }
        public string Bookmarks { get; set; }
        public List<long> PlaylistIds { get; set; }
        public List<YLibraryPlaylistResponse.YandexLibraryPlaylist> Playlists { get; set; }
        public bool Verified { get; set; }
        public YOwner Owner { get; set; }
        public bool Visibility { get; set; }
        public List<YProfile> Profiles { get; set; }
        public YLikedCounts Counts { get; set; }
        public bool HasTracks { get; set; }
        public bool IsRadioAvailable { get; set; }

        public static YLibraryHistoryResponse FromJson(JToken json)
        {
            var r = YLibraryPlaylistResponse.FromJson(json);

            return new YLibraryHistoryResponse
            {
                Success = r.Success,
                Bookmarks = r.Bookmarks,
                BookmarksPlaylistsIds = r.BookmarksPlaylistsIds,
                Playlists = r.Playlists,
                PlaylistIds = r.PlaylistIds,
                Verified = r.Verified,
                Owner = r.Owner,
                Visibility = r.Visibility,
                Profiles = r.Profiles,
                Counts = r.Counts,
                HasTracks = r.HasTracks,
                IsRadioAvailable = r.IsRadioAvailable
            };
        }
    }
}