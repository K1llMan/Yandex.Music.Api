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
        /// API альбомов
        /// </summary>
        public YAlbumAPI Album { get; }

        /// <summary>
        /// API исполнителей
        /// </summary>
        public YArtistAPI Artist { get; }

        /// <summary>
        /// API главной страницы
        /// </summary>
        public YLandingAPI Landing { get; }

        /// <summary>
        /// API библиотеки
        /// </summary>
        public YLibraryAPI Library { get; }

        /// <summary>
        /// API плейлистов
        /// </summary>
        public YPlaylistAPI Playlist { get; }

        /// <summary>
        /// API радио
        /// </summary>
        public YRadioAPI Radio { get; }

        /// <summary>
        /// API поиска
        /// </summary>
        public YSearchAPI Search { get; }

        /// <summary>
        /// API треков
        /// </summary>
        public YTrackAPI Track { get; }

        /// <summary>
        /// API пользователя
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
            Landing = new YLandingAPI(this);
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