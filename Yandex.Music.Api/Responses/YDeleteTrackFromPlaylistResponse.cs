using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Responses
{
    public class YDeleteTrackFromPlaylistResponse
    {
        public bool Success { get; set; }
        public YPlaylistResponse Playlist { get; set; }

        public static YDeleteTrackFromPlaylistResponse FromJson(JToken json)
        {
            var response = new YDeleteTrackFromPlaylistResponse
            {
                Success = json["success"].ToObject<bool>(),
                Playlist = YPlaylistResponse.FromJson(json["playlist"])
            };

            return response;
        }
    }
}