using System;

using Yandex.Music.Api.Models.Playlist;

namespace Yandex.Music.Api.Models.Library
{
    public class YLibraryPlaylists
    {
        public YPlaylist Playlist { get; set; }
        public DateTime Timestamp { get; set; }
    }
}