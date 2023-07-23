using System.Collections.Generic;

using Newtonsoft.Json;

using Yandex.Music.Api.Models.Album;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Common.Cover;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Models.Artist
{
    public class YArtistBriefInfo
    {
        public YButton ActionButton { get; set; }
        public List<YAlbum> Albums { get; set; }
        [JsonProperty(ItemConverterType = typeof(YCoverConverter))]
        public List<YCover> AllCovers { get; set; }
        public List<YAlbum> AlsoAlbums { get; set; }
        public YArtist Artist { get; set; }
        public string BackgroundVideoUrl { get; set; }
        public YBandlinkScannerLink BandlinkScannerLink { get; set; }
        public List<YClip> Clips { get; set; }
        public List<YConcert> Concerts { get; set; }
        public YCustomWave CustomWave { get; set; }
        public bool HasPromotions { get; set; }
        public List<string> LastReleaseIds { get; set; }
        public List<YAlbum> LastReleases { get; set; }
        public List<YPlaylistUidPair> PlaylistIds { get; set; }
        public List<YPlaylist> Playlists { get; set; }
        public List<YTrack> PopularTracks { get; set; }
        public List<YArtist> SimilarArtists { get; set; }
        public YStats Stats { get; set; }
        public List<YVideo> Videos { get; set; }
        public List<YVinyl> Vinyls { get; set; }
        public List<YLink> Links { get; set; }
    }
}