using Yandex.Music.Api.API;

namespace Yandex.Music.Api
{
    /// <summary>
    /// Yandex Music API
    /// </summary>
    public class YandexMusicApi
    {
        #region Ветки API

        /// <summary>
        /// Accounts API
        /// </summary>
        public YAccountsAPI AccountsApi { get; set; }

        /// <summary>
        /// Album API
        /// </summary>
        public YAlbumAPI AlbumAPI { get; set; }

        /// <summary>
        /// Library API
        /// </summary>
        public YLibraryAPI LibraryAPI { get; set; }

        /// <summary>
        /// Playlist API
        /// </summary>
        public YPlaylistAPI PlaylistAPI { get; set; }

        /// <summary>
        /// Search API
        /// </summary>
        public YSearchAPI SearchAPI { get; set; }

        /// <summary>
        /// Track API
        /// </summary>
        public YTrackAPI TrackAPI { get; set; }

        /// <summary>
        /// User API
        /// </summary>
        public YUserAPI UserAPI { get; set; }

        #endregion Ветки API

        #region Основные функции

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public YandexMusicApi()
        {
            AccountsApi = new YAccountsAPI();
            AlbumAPI = new YAlbumAPI();
            LibraryAPI = new YLibraryAPI();
            PlaylistAPI = new YPlaylistAPI();
            SearchAPI = new YSearchAPI();
            TrackAPI = new YTrackAPI();
            UserAPI = new YUserAPI();
        }

        #endregion Основные функции
    }
}