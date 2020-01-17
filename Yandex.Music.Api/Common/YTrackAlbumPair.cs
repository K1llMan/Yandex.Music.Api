using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Common
{
    public class YTrackAlbumPair
    {
        public string Id { get; set; }
        public string AlbumId { get; set; }

        internal static YTrackAlbumPair FromJson(JToken json)
        {
            return new YTrackAlbumPair
            {
                Id = json["id"].ToObject<string>(),
                AlbumId = json["albumId"].ToObject<string>()
            };
        }
    }
}
