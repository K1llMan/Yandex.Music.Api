using System.Collections.Generic;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Common.YPlaylist;

namespace Yandex.Music.Api.Responses
{
    public class YLibraryPlaylistResponse
    {
        public bool Success { get; set; }
        public List<string> BookmarksPlaylistsIds { get; set; }
        public List<string> Bookmarks { get; set; }
        public List<long> PlaylistIds { get; set; }
        public List<YPlaylist> Playlists { get; set; }
        public bool Verified { get; set; }
        public YOwner Owner { get; set; }
        public bool Visibility { get; set; }
        public List<YProfile> Profiles { get; set; }
        public YLikedCounts Counts { get; set; }
        public bool HasTracks { get; set; }
        public bool IsRadioAvailable { get; set; }
    }
}