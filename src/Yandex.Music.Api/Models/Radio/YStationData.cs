using System.Collections.Generic;

using Yandex.Music.Api.Models.Artist;

namespace Yandex.Music.Api.Models.Radio
{
    public class YStationData
    {
        public List<YArtist> Artists { get; set; }
        public YBrand Brand { get; set; }
        public string Description { get; set; }
        public string ImageUri { get; set; }
        public string Title { get; set; }
    }
}