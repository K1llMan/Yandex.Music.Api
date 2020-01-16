using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Responses
{
    public class YInsertTrackToPlaylistResponse
    {
        public bool Success { get; set; }
        public YPlaylistResponse Playlist { get; set; }

        public static YInsertTrackToPlaylistResponse FromJson(JToken json)
        {
            var response = new YInsertTrackToPlaylistResponse
            {
                Success = json["success"].ToObject<bool>(),
                Playlist = YPlaylistResponse.FromJson(json["playlist"])
            };

            return response;
        }
    }
}