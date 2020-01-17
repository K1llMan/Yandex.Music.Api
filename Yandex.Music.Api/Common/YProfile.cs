using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Common
{
    public class YProfile
    {
        public string Provider { get; set; }
        public List<string> Addresses { get; set; }

        internal static YProfile FromJson(JToken json)
        {
            return new YProfile
            {
                Provider = json["provider"].ToObject<string>(),
                Addresses = json["addresses"].Select(x => x.ToObject<string>()).ToList()
            };
        }
    }
}
