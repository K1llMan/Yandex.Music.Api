using System.Collections.Generic;

using Yandex.Music.Api.Models.Playlist;

namespace Yandex.Music.Api.Models.Landing.Entity.Entities
{
    public class YPersonalPlaylist
    {
        public YPlaylist Data { get; set; }
        public List<string> Description { get; set; }
        public bool Notify { get; set; }
        public string PreviewDescription { get; set; }
        public bool Ready { get; set; }
        public string Type { get; set; }
    }
}