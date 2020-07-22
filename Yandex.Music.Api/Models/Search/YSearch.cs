using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Search.Album;
using Yandex.Music.Api.Models.Search.Artist;
using Yandex.Music.Api.Models.Search.Playlist;
using Yandex.Music.Api.Models.Search.Track;
using Yandex.Music.Api.Models.Search.User;
using Yandex.Music.Api.Models.Search.Video;

namespace Yandex.Music.Api.Models.Search
{
    public class YSearch
    {
        #region Свойства

        public YSearchResult<YSearchAlbumModel> Albums { get; set; }
        public YSearchResult<YSearchArtistModel> Artists { get; set; }

        public YSearchBest Best { get; set; }

        public bool MisspellCorrected { get; set; }
        public string MisspellOriginal { get; set; }
        public string MisspellResult { get; set; }
        public bool NoCorrect { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public YSearchResult<YSearchPlaylistModel> Playlists { get; set; }
        public string SearchRequestId { get; set; }
        public string Text { get; set; }
        public YSearchResult<YSearchTrackModel> Tracks { get; set; }

        public YSearchType Type { get; set; }
        public YSearchResult<YSearchUserModel> Users { get; set; }
        public YSearchResult<YSearchVideoModel> Videos { get; set; }

        #endregion
    }
}