using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Responses
{
    public class YPlaylistChangeResponse
    {
        public bool Success { get; set; }
        public YPlaylist Playlist { get; set; }
    }
}