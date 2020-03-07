using System.Collections.Generic;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Responses
{
    public class YLibraryPlaylistResponse
    {
        public bool Success { get; set; }
        public string BookmarksPlaylistsIds { get; set; }
        public string Bookmarks { get; set; }
        public List<long> PlaylistIds { get; set; }
        public List<YandexLibraryPlaylist> Playlists { get; set; }
        public bool Verified { get; set; }
        public YOwner Owner { get; set; }
        public bool Visibility { get; set; }
        public List<YProfile> Profiles { get; set; }
        public YLikedCounts Counts { get; set; }
        public bool HasTracks { get; set; }
        public bool IsRadioAvailable { get; set; }

        public class YandexLibraryPlaylist
        {
            public YOwner Owner { get; set; }
            public long? Revision { get; set; }
            public long? Kind { get; set; }
            public bool? Available { get; set; }
            public long? Uid { get; set; }
            public string Title { get; set; }
            public long? Snapshot { get; set; }
            public long? TrackCount { get; set; }
            public string Visibility { get; set; }
            public bool? Collective { get; set; }
            public string Created { get; set; }
            public string Modified { get; set; }
            public bool? IsBanner { get; set; }
            public bool? IsPremiere { get; set; }
            public long? DurationMs { get; set; }
            public YCover Cover { get; set; }
            public string OgImage { get; set; }
            public List<YandexLibraryPlaylistTrack> Tracks { get; set; }
            public string Tags { get; set; }
            public string Prerolls { get; set; }

            public class YandexLibraryPlaylistTrack
            {
                public long? Id { get; set; }
                public long? AlbumId { get; set; }
                public string Timestamp { get; set; }
            }
        }
    }
}