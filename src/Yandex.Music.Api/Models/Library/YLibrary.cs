using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Library
{
    public class YLibrary
    {
        public string PlaylistUuid { get; set; }
        public int Revision { get; set; }
        public List<YLibraryTrack> Tracks { get; set; }
        public string Uid { get; set; }
    }
}
