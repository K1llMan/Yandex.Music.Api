using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Models.Playlist
{
    public class YPlaylistPrerolls
    {
        public string Id { get; set; }
        public string Link { get; set; }

        internal static YPlaylistPrerolls FromJson(JToken json)
        {
            if (json == null)
            {
                return null;
            }

            return new YPlaylistPrerolls
            {
                Id = json.SelectToken("id")?.ToObject<string>(),
                Link = json.SelectToken("link")?.ToObject<string>()
            };
        }
    }
}