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
        /// Album API
        /// </summary>
        public YAlbumAPI AlbumAPI { get; set; }

        /// <summary>
        /// Artist API
        /// </summary>
        public YArtistAPI ArtistAPI { get; set; }

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
            AlbumAPI = new YAlbumAPI();
            ArtistAPI = new YArtistAPI();
            LibraryAPI = new YLibraryAPI();
            PlaylistAPI = new YPlaylistAPI();
            SearchAPI = new YSearchAPI();
            TrackAPI = new YTrackAPI();
            UserAPI = new YUserAPI();
        }

        #endregion Основные функции
    }
}