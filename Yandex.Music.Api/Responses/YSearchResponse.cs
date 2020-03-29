using Yandex.Music.Api.Models.Search;
using Yandex.Music.Api.Models.Search.Album;
using Yandex.Music.Api.Models.Search.Artist;
using Yandex.Music.Api.Models.Search.Playlist;
using Yandex.Music.Api.Models.Search.Track;
using Yandex.Music.Api.Models.Search.User;
using Yandex.Music.Api.Models.Search.Video;

namespace Yandex.Music.Api.Responses
{
    public class YSearchResponse
    {
        public string Text { get; set; }
        public YSearchResult<YSearchAlbumModel> Albums { get; set; }
        public YSearchResult<YSearchTrackModel> Tracks { get; set; }
        public YSearchResult<YSearchArtistModel> Artists { get; set; }
        public YSearchResult<YSearchVideoModel> Videos { get; set; }
        public YSearchResult<YSearchPlaylistModel> Playlists { get; set; }
        public YSearchResult<YSearchUserModel> Users { get; set; }

        public string RequestId { get; set; }

        public string SearchRequestId { get; set; }
//        extendedParams
//        public misspell

        public YSearchPager Pager { get; set; }
        public YSearchCounter Counts { get; set; }
    }
}