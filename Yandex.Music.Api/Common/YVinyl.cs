using System.Collections.Generic;

namespace Yandex.Music.Api.Common
{
    public class YVinyl
    {
        public string OfferId { get; set; }
        public string Url { get; set; }
        public string Picture { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public List<string> ArtistIds { get; set; }
        public string Media { get; set; }
    }
}
