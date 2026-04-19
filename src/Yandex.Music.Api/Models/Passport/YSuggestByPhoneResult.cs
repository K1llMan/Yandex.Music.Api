using Newtonsoft.Json;

using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Passport
{
    public class YSuggestByPhoneResult
    {
        [JsonProperty("accounts")]
        public List<YSuggestAccount> Accounts { get; set; }

        [JsonProperty("allowed_registration_flows")]
        public List<string> AllowedRegistrationFlows { get; set; }

        [JsonProperty("uid_from_bb")]
        public string UidFromBb { get; set; }
    }
}