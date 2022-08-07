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
        public YAlbumAPI Album { get; }

        /// <summary>
        /// Artist API
        /// </summary>
        public YArtistAPI Artist { get; }

        /// <summary>
        /// Library API
        /// </summary>
        public YLibraryAPI Library { get; }

        /// <summary>
        /// Playlist API
        /// </summary>
        public YPlaylistAPI Playlist { get; }

        /// <summary>
        /// Radio API
        /// </summary>
        public YRadioAPI Radio { get; }

        /// <summary>
        /// Search API
        /// </summary>
        public YSearchAPI Search { get; }

        /// <summary>
        /// Track API
        /// </summary>
        public YTrackAPI Track { get; }

        /// <summary>
        /// User API
        /// </summary>
        public YUserAPI User { get; }

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
            Radio = new YRadioAPI(this);
            Search = new YSearchAPI(this);
            Track = new YTrackAPI(this);
            User = new YUserAPI(this);
        }

        #endregion Основные функции
    }
}