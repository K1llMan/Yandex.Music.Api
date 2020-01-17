using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Common
{
    public class YOwner
    {
        public string Uid { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public bool? Verified { get; set; }

        internal static YOwner FromJson(JToken json)
        {
            if (json == null)
            {
                return null;
            }

            return new YOwner
            {
                Uid = json.SelectToken("uid")?.ToObject<string>(),
                Login = json.SelectToken("login")?.ToObject<string>(),
                Name = json.SelectToken("name")?.ToObject<string>(),
                Sex = json.SelectToken("sex")?.ToObject<string>(),
                Verified = json.SelectToken("verified")?.ToObject<bool>()
            };
        }
    }
}
