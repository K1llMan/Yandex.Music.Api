using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Models.Artist
{
    public class YArtistCover
    {
        public string Type { get; set; }
        public string Prefix { get; set; }
        public string Url { get; set; }

        internal static YArtistCover FromJson(JToken json)
        {
            if (json == null)
            {
                return null;
            }

            return new YArtistCover
            {
                Type = json.SelectToken("type")?.ToObject<string>(),
                Prefix = json.SelectToken("prefix")?.ToObject<string>(),
                Url = json.SelectToken("uri")?.ToObject<string>()
            };
        }
    }
}