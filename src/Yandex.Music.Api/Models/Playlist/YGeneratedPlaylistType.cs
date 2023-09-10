namespace Yandex.Music.Api.Models.Playlist
{
    public enum YGeneratedPlaylistType
    {
        None,

        /// <summary>
        /// Редакторский список
        /// </summary>
        Editorial,

        /// <summary>
        /// Плейлист дня
        /// </summary>
        PlaylistOfTheDay,

        /// <summary>
        /// Премьера
        /// </summary>
        RecentTracks,

        /// <summary>
        /// Дежавю
        /// </summary>
        NeverHeard,

        /// <summary>
        /// Тайник
        /// </summary>
        MissedLikes,

        /// <summary>
        /// Алиса
        /// </summary>
        Origin,

        /// <summary>
        /// Кинопоиск
        /// </summary>
        Kinopoisk
    }
}