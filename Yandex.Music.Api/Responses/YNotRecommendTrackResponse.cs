using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Responses
{
    public class YNotRecommendTrackResponse
    {
        public bool Success { get; set; }
        public string Act { get; set; }

        public static YNotRecommendTrackResponse FromJson(JToken json)
        {
            return new YNotRecommendTrackResponse
            {
                Success = json["success"].ToObject<bool>(),
                Act = json["act"].ToObject<string>()
            };
        }
    }
}