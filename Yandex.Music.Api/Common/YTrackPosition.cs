using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Common
{
    public class YTrackPosition
    {
        public int Volume { get; set; }
        public int Index { get; set; }

        internal static YTrackPosition FromJson(JToken json)
        {
            return new YTrackPosition
            {
                Volume = json["volume"].ToObject<int>(),
                Index = json["index"].ToObject<int>()
            };
        }
    }
}
