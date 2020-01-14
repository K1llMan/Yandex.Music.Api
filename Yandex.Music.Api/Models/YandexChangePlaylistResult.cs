namespace Yandex.Music.Api.Models
{
    public class YandexChangePlaylistResult
    {
        public bool Success { get; set; }
        public YandexGetLibraryResult.YandexLibraryPlaylist Playlist { get; set; }
    }
}