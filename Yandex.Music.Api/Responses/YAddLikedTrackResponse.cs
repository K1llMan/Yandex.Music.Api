using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Responses
{
    public class YAddLikedTrackResponse
    {
        public bool Success { get; set; }
        public string Act { get; set; }

        public static YAddLikedTrackResponse FromJson(JToken json)
        {
            return new YAddLikedTrackResponse
            {
                Success = json["success"].ToObject<bool>(),
                Act = json["act"].ToObject<string>()
            };
        }
    }
}