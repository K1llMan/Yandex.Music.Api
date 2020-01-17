using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
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

        public static YLibraryPlaylistResponse FromJson(JToken json)
        {
            var playlists = new List<YLibraryPlaylistResponse.YandexLibraryPlaylist>();

            foreach (var x in json["playlists"])
            {
                var playlistOwner = new YOwner
                {
                    Uid = x["owner"]["uid"].ToObject<string>(),
                    Login = x["owner"]["login"].ToObject<string>(),
                    Name = x["owner"]["name"].ToObject<string>(),
                    Sex = x["owner"]["sex"]?.ToObject<string>(),
                    Verified = x["owner"]["verified"]?.ToObject<bool>()
                };

                var tracks = x.SelectToken("tracks")?.Select(f =>
                    new YandexLibraryPlaylist.YandexLibraryPlaylistTrack
                    {
                        Id = f["id"]?.ToObject<long?>(),
                        Timestamp = f["timestamp"]?.ToObject<string>(),
                        AlbumId = f["albumId"]?.ToObject<long?>()
                    }).ToList();

                var libraryCover = YCover.FromJson(x.SelectToken("cover"));

                var playlist = new YandexLibraryPlaylist
                {
                    Owner = playlistOwner,
                    Available = x["available"]?.ToObject<bool>(),
                    Uid = x["uid"]?.ToObject<long>(),
                    Kind = x["kind"]?.ToObject<long>(),
                    Title = x["title"]?.ToObject<string>(),
                    Revision = x["revision"]?.ToObject<long>(),
                    Snapshot = x["snapshot"]?.ToObject<long>(),
                    TrackCount = x["trackCount"]?.ToObject<long>(),
                    Visibility = x["visibility"]?.ToObject<string>(),
                    Collective = x["collective"]?.ToObject<bool>(),
                    Created = x["created"]?.ToObject<string>(),
                    Modified = x["modified"]?.ToObject<string>(),
                    IsBanner = x["isBanner"]?.ToObject<bool>(),
                    IsPremiere = x["isPremiere"]?.ToObject<bool>(),
                    DurationMs = x["durationMs"]?.ToObject<long>(),
                    Cover = libraryCover,
                    OgImage = x["ogImage"]?.ToObject<string>(),
                    Tracks = tracks,
                    Tags = x["tags"]?.ToString(),
                    Prerolls = x["prerolls"]?.ToString(),
                };
                playlists.Add(playlist);
            }

            var libraryOwner = new YOwner
            {
                Uid = json["owner"]["uid"].ToObject<string>(),
                Login = json["owner"]["login"].ToObject<string>(),
                Name = json["owner"]["name"].ToObject<string>(),
                Sex = string.Empty,
                Verified = null
            };

            var profiles = json["profiles"].Select(x => new YProfile
            {
                Provider = x["provider"].ToObject<string>(),
                Addresses = x["addresses"].Select(f => f.ToObject<string>()).ToList()
            }).ToList();

            var counts = new YLikedCounts
            {
                LikedArtists = json["counts"]["likedArtists"].ToObject<long>(),
                LikedAlbums = json["counts"]["likedAlbums"].ToObject<long>(),
            };

            return new YLibraryPlaylistResponse
            {
                Success = json["success"].ToObject<bool>(),
                BookmarksPlaylistsIds = json["bookmarksPlaylistsIds"].ToString(),
                Bookmarks = json["bookmarks"].ToString(),
                PlaylistIds = json["playlistIds"].Select(x => x.ToObject<long>()).ToList(),
                Playlists = playlists,
                Verified = json["verified"].ToObject<bool>(),
                Owner = libraryOwner,
                Visibility = json["visibility"].ToObject<bool>(),
                Profiles = profiles,
                Counts = counts,
                HasTracks = json["hasTracks"].ToObject<bool>(),
                IsRadioAvailable = json["isRadioAvailable"].ToObject<bool>()
            };
        }




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
