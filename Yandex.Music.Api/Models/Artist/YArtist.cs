using System.Collections.Generic;

using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Models.Artist
{
    public class YArtist
    {
        #region Свойства

        public List<YAlbum> Albums { get; set; }
        public List<YArtistCover> AllCovers { get; set; }
        public List<YAlbum> AlsoAlbums { get; set; }
        public YArtist Artist { get; set; }
        public bool Available { get; set; }
        public bool Composer { get; set; }
        public List<YConcert> Concerts { get; set; }
        public List<string> Countries { get; set; }
        public YArtistCounts Counts { get; set; }
        public YArtistCover Cover { get; set; }
        public List<string> DbAliases { get; set; }
        public YDescription Description { get; set; }
        public string EndDate { get; set; }
        public string EnWikipediaLink { get; set; }
        public List<string> Genres { get; set; }
        public bool HasPromotions { get; set; }
        public string Id { get; set; }
        public string InitDate { get; set; }
        public List<string> LastReleaseIds { get; set; }
        public int LikesCount { get; set; }
        public List<YLink> Links { get; set; }
        public string Name { get; set; }
        public string OgImage { get; set; }
        public List<YPlaylistUidPair> PlaylistIds { get; set; }
        public List<YPlaylist> Playlists { get; set; }
        public List<YTrack> PopularTracks { get; set; }
        public YArtistRatings Ratings { get; set; }
        public List<YArtist> SimilarArtists { get; set; }
        public bool TicketsAvailable { get; set; }
        public bool Various { get; set; }
        public List<YVideo> Videos { get; set; }
        public List<YVinyl> Vinyls { get; set; }
        public string YaMoneyId { get; set; }

        #endregion
    }
}