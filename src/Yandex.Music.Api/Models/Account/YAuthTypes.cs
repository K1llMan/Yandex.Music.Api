using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account
{
    public class YAuthTypes : YAuthBase
    {
        [JsonProperty("primary_alias_type")]
        public string PrimaryAliasType { get; set; }

        [JsonProperty("csrf_token")]
        public string CsrfToken { get; set; }

        [JsonProperty("use_new_suggest_by_phone")]
        public bool UseNewSuggestByPhone { get; set; }

        [JsonProperty("is_rfc_2fa_enabled")]
        public bool IsRfc2faEnabled { get; set; }

        [JsonProperty("track_id")]
        public string TrackId { get; set; }

        [JsonProperty("can_authorize")]
        public string CanAuthorize { get; set; }

        [JsonProperty("preferred_auth_method")]
        public YAuthMethod PreferredAuthMethod { get; set; }

        [JsonProperty("auth_methods")]
        public List<YAuthMethod> AuthMethods { get; set; }

        [JsonProperty("can_register")]
        public bool CanRegister { get; set; }

        public string Country { get; set; }

        [JsonProperty("phone_number")]
        public YPhoneNumber PhoneNumberNumber { get; set; }

        [JsonProperty("magic_link_email")]
        public string MagicLinkEmail { get; set; }
    }
}