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
        public YAlbumAPI Album { get; set; }

        /// <summary>
        /// Artist API
        /// </summary>
        public YArtistAPI Artist { get; set; }

        /// <summary>
        /// Library API
        /// </summary>
        public YLibraryAPI Library { get; set; }

        /// <summary>
        /// Playlist API
        /// </summary>
        public YPlaylistAPI Playlist { get; set; }

        /// <summary>
        /// Search API
        /// </summary>
        public YSearchAPI Search { get; set; }

        /// <summary>
        /// Track API
        /// </summary>
        public YTrackAPI Track { get; set; }

        /// <summary>
        /// User API
        /// </summary>
        public YUserAPI User { get; set; }

        #endregion Ветки API

        #region Основные функции

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public YandexMusicApi()
        {
            Album = new YAlbumAPI(this);
            Artist = new YArtistAPI(this);
            Library = new YLibraryAPI(this);
            Playlist = new YPlaylistAPI(this);
            Search = new YSearchAPI(this);
            Track = new YTrackAPI(this);
            User = new YUserAPI(this);
        }

        #endregion Основные функции
    }
}