using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Responses
{
    public class YSetLikedTrackResponse
    {
        public string Result { get; set; }

        public static YSetLikedTrackResponse FromJson(JToken json)
        {
            return new YSetLikedTrackResponse
            {
                Result = json["result"].ToObject<string>()
            };
        }
    }
}