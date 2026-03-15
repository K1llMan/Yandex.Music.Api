using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Passport
{
    public class YPassportPerson
    {
        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }
    }
}