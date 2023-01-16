using System;
using System.Reflection;

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
        public YAlbumAPI Album { get; internal set; }

        /// <summary>
        /// API исполнителей
        /// </summary>
        public YArtistAPI Artist { get; internal set; }

        /// <summary>
        /// API главной страницы
        /// </summary>
        public YLandingAPI Landing { get; internal set; }

        /// <summary>
        /// API библиотеки
        /// </summary>
        public YLibraryAPI Library { get; internal set; }

        /// <summary>
        /// API плейлистов
        /// </summary>
        public YPlaylistAPI Playlist { get; internal set; }

        /// <summary>
        /// API радио
        /// </summary>
        public YRadioAPI Radio { get; internal set; }

        /// <summary>
        /// API поиска
        /// </summary>
        public YSearchAPI Search { get; internal set; }

        /// <summary>
        /// API треков
        /// </summary>
        public YTrackAPI Track { get; internal set; }
        
        /// <summary>
        /// API очередей
        /// </summary>
        public YQueueAPI Queue { get; internal set; }

        /// <summary>
        /// API пользователя
        /// </summary>
        public YUserAPI User { get; internal set; }

        #endregion Ветки API

        #region Основные функции

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public YandexMusicApi()
        {
            foreach (PropertyInfo property in GetType().GetProperties())
                property.SetValue(this, Activator.CreateInstance(property.PropertyType, this));
        }

        #endregion Основные функции
    }
}