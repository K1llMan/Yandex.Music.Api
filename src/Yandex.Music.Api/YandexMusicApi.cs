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
        public YAlbumAPI Album { get; private set; }

        /// <summary>
        /// Artist API
        /// </summary>
        public YArtistAPI Artist { get; private set; }

        /// <summary>
        /// Library API
        /// </summary>
        public YLibraryAPI Library { get; private set; }

        /// <summary>
        /// Playlist API
        /// </summary>
        public YPlaylistAPI Playlist { get; private set; }

        /// <summary>
        /// Radio API
        /// </summary>
        public YRadioAPI Radio { get; private set; }

        /// <summary>
        /// Search API
        /// </summary>
        public YSearchAPI Search { get; private set; }

        /// <summary>
        /// Track API
        /// </summary>
        public YTrackAPI Track { get; private set; }

        /// <summary>
        /// User API
        /// </summary>
        public YUserAPI User { get; private set; }

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