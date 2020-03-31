namespace Yandex.Music.Api.Common
{
    /// <summary>
    /// Тип объекта поиска
    /// </summary>
    public enum YSearchType
    {
        /// <summary>
        /// Отсутствует значение
        /// </summary>
        None,
        /// <summary>
        /// Артисты
        /// </summary>
        Artist,
        /// <summary>
        /// Альбомы
        /// </summary>
        Album,
        /// <summary>
        /// Все
        /// </summary>
        All,
        /// <summary>
        /// Плейлисты
        /// </summary>
        Playlist,
        /// <summary>
        /// Видео
        /// </summary>
        Video,
        /// <summary>
        /// Треки
        /// </summary>
        Track,
        /// <summary>
        /// Пользователи
        /// </summary>
        User
    }
}