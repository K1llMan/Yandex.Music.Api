using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Artist
{
    public class YArtist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Various { get; set; }
        public bool Composer { get; set; }
        public YArtistCover Cover { get; set; }
        public List<string> Genres { get; set; }
    }
}