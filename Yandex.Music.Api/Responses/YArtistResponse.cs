using System.Collections.Generic;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Common.YPlaylist;
using Yandex.Music.Api.Common.YTrack;
using Yandex.Music.Api.Models.Artist;

namespace Yandex.Music.Api.Responses
{
    public class YArtistResponse
    {
        public List<YAlbum> Albums { get; set; }
        public List<YArtistCover> AllCovers { get; set; }
        public List<YAlbum> AlsoAlbums { get; set; }
        public YArtist Artist { get; set; }
        public List<YConcert> Concerts { get; set; }
        public bool HasPromotions { get; set; }
        public List<string> LastReleaseIds { get; set; }
        public List<YPlaylistUidPair> PlaylistIds { get; set; }
        public List<YPlaylist> Playlists { get; set; }
        public List<YTrack> PopularTracks { get; set; }
        public List<YArtist> SimilarArtists { get; set; }
        public List<YVideo> Videos { get; set; }
        public List<YVinyl> Vinyls { get; set; }
    }
}