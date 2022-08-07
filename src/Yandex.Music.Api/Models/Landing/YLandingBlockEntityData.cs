using System.Collections.Generic;

using Yandex.Music.Api.Models.Playlist;

namespace Yandex.Music.Api.Models.Landing
{
    public class YLandingBlockEntityData
    {
        public YPlaylist Data { get; set; }
        public List<string> Description { get; set; }
        public bool Notify { get; set; }
        public string PreviewDescription { get; set; }
        public bool Ready { get; set; }
        public YGeneratedPlaylistType Type { get; set; }
    }
}