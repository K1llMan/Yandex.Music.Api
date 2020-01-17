using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Common
{
    public class YCountsTracks
    {
        public int Favorite { get; set; }
        public int All { get; set; }
        public int Ugc { get; set; }

        internal static YCountsTracks FromJson(JToken json)
        {
            return new YCountsTracks
            {
                Favorite = json["favorite"].ToObject<int>(),
                All = json["all"].ToObject<int>(),
                Ugc = json["ugc"].ToObject<int>()
            };
        }
    }
}
