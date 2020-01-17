using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Common
{
    public class YTrackPosition
    {
        public int? Volume { get; set; }
        public int? Index { get; set; }

        internal static YTrackPosition FromJson(JToken json)
        {
            if (json == null)
            {
                return null;
            }

            return new YTrackPosition
            {
                Volume = json.SelectToken("volume")?.ToObject<int>(),
                Index = json.SelectToken("index")?.ToObject<int>()
            };
        }
    }
}
