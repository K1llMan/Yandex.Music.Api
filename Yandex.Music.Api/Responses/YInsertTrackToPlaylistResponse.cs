using Yandex.Music.Api.Common;
using Yandex.Music.Api.Common.YPlaylist;

namespace Yandex.Music.Api.Responses
{
    public class YInsertTrackToPlaylistResponse
    {
        public bool Success { get; set; }
        public YPlaylist Playlist { get; set; }
    }
}