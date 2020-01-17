using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Models.Playlist
{
    public class YPlaylistPlayCounter
    {
        public int? Value { get; set; }
        public string Description { get; set; }
        public bool? Updated { get; set; }

        internal static YPlaylistPlayCounter FromJson(JToken json)
        {
            if (json == null)
            {
                return null;
            }

            return new YPlaylistPlayCounter
            {
                Value = json.SelectToken("value")?.ToObject<int>(),
                Description = json.SelectToken("description")?.ToObject<string>(),
                Updated = json.SelectToken("updated")?.ToObject<bool>()
            };
        }
    }
}