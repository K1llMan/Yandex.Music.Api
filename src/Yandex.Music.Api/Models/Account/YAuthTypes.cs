using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account
{
    public class YPhone
    {
        [JsonProperty("masked_e164")]
        public string MaskedE164 { get; set; }

        public string E164 { get; set; }

        public string International { get; set; }

        [JsonProperty("masked_original")]
        public string MaskedOriginal { get; set; }

        public string Original { get; set; }

        [JsonProperty("masked_international")]
        public string MaskedInternational { get; set; }
    }


    public class YAuthTypes : YAuthBase
    {
        [JsonProperty("primary_alias_type")]
        public string PrimaryAliasType { get; set; }

        [JsonProperty("csrf_token")]
        public string CsrfToken { get; set; }

        [JsonProperty("use_new_suggest_by_phone")]
        public bool UseNewSuggestByPhone { get; set; }

        [JsonProperty("track_id")]
        public string TrackId { get; set; }

        [JsonProperty("can_authorize")]
        public string CanAuthorize { get; set; }

        [JsonProperty("preferred_auth_method")]
        public string PreferredAuthMethod { get; set; }

        [JsonProperty("auth_methods")]
        public List<string> AuthMethods { get; set; }

        [JsonProperty("can_register")]
        public bool CanRegister { get; set; }

        public string Country { get; set; }

        [JsonProperty("phone_number")]
        public YPhone PhoneNumber { get; set; }

        [JsonProperty("magic_link_email")]
        public string MagicLinkEmail { get; set; }
    }
}