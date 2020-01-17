using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Models.Playlist
{
    public class YPlaylistMadeFor
    {
        public YOwner UserInfo { get; set; }
        public YMadeForCaseForms MadeFor { get; set; }

        internal static YPlaylistMadeFor FromJson(JToken json)
        {
            if (json == null)
            {
                return null;
            }

            return new YPlaylistMadeFor
            {
                UserInfo = YOwner.FromJson(json.SelectToken("userInfo")),
                MadeFor = YMadeForCaseForms.FromJson(json.SelectToken("caseForms"))
            };
        }
        
        public class YMadeForCaseForms
        {
            public string Nominative { get; set; }
            public string Genitive { get; set; }
            public string Dative { get; set; }
            public string Accusative { get; set; }
            public string Instrumental { get; set; }
            public string Prepositional { get; set; }

            internal static YMadeForCaseForms FromJson(JToken json)
            {
                if (json == null)
                {
                    return null;
                }

                return new YMadeForCaseForms
                {
                    Nominative = json.SelectToken("nominative")?.ToObject<string>(),
                    Genitive = json.SelectToken("genitive")?.ToObject<string>(),
                    Dative = json.SelectToken("dative")?.ToObject<string>(),
                    Accusative = json.SelectToken("accusative")?.ToObject<string>(),
                    Instrumental = json.SelectToken("instrumental")?.ToObject<string>(),
                    Prepositional = json.SelectToken("prepositional")?.ToObject<string>(),
                };
            }
        }
    }
}