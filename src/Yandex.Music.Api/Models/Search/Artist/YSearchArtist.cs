using System.Collections.Generic;

using Newtonsoft.Json;

using Yandex.Music.Api.Models.Common.Cover;

namespace Yandex.Music.Api.Models.Search.Artist
{
    public class YSearchArtist
    {
        public bool Composer { get; set; }
        [JsonConverter(typeof(YCoverConverter))]
        public YCover Cover { get; set; }
        public List<string> Decomposed { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Various { get; set; }
    }
}