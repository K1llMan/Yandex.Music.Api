using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Common
{
    public class YTrackNormalization
    {
        public double Gain { get; set; }
        public double Peak { get; set; }

        internal static YTrackNormalization FromJson(JToken json)
        {
            if (json == null)
            {
                return null;
            }
            
            return new YTrackNormalization
            {
                Gain = json.SelectToken("gain").ToObject<double>(),
                Peak = json.SelectToken("peak").ToObject<double>()
            };
        }
    }
}
