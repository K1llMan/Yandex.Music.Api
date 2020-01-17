using System;
using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Common
{
    public class YCover
    {
        public string Type { get; set; }
        public string Prefix { get; set; }
        public string Url { get; set; }
        
//        public bool Custom { get; set; }
//        public string Dir { get; set; }
//        public string Version { get; set; }

        internal static YCover FromJson(JToken json)
        {
            if (json == null)
            {
                return null;
            }

            return new YCover
            {
                Type = json.SelectToken("type")?.ToObject<string>(),
                Prefix = json.SelectToken("prefix")?.ToObject<string>(),
                Url = json.SelectToken("uri")?.ToObject<string>()
            };
        }
    }
}
