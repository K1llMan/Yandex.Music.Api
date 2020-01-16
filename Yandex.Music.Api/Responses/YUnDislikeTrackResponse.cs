using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Responses
{
    public class YUnDislikeTrackResponse
    {
        public string Result { get; set; }

        public static YUnDislikeTrackResponse FromJson(JToken json)
        {
            return new YUnDislikeTrackResponse
            {
                Result = json["result"].ToObject<string>()
            };
        }
    }
}