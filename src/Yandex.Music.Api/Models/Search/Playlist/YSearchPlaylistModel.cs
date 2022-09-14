using System.Collections.Generic;

using Yandex.Music.Api.Models.Playlist;

namespace Yandex.Music.Api.Models.Search.Playlist
{
    public class YSearchPlaylistModel: YPlaylist
    {
        public string CoverUri { get; set; }
        public List<string> Regions { get; set; }
    }
}