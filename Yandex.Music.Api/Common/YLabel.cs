using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Common
{
    public class YLabel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        internal static YLabel FromJson(JToken json)
        {
            return new YLabel
            {
                Id = json["id"].ToObject<string>(),
                Name = json["name"].ToObject<string>()
            };
        }
    }
}
