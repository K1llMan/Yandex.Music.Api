using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Responses
{
    public class YArtistResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool? Various { get; set; }
        public bool? Composer { get; set; }
        public YCover Cover { get; set; }
        public string[] Genres { get; set; }
    }
}