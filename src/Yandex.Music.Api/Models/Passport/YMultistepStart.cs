using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Passport
{
    public class YMultistepStart : PassportResponseBase
    {
        [JsonProperty("track_id")]
        public string TrackId { get; set; }

        [JsonProperty("can_authorize")]
        public bool CanAuthorize { get; set; }

        [JsonProperty("can_register")]
        public bool CanRegister { get; set; }

        [JsonProperty("is_rfc_2fa_enabled")]
        public bool IsRfc2faEnabled { get; set; }

        [JsonProperty("allowed_account_types")]
        public List<string> AllowedAccountTypes { get; set; }

        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        [JsonProperty("primary_alias_type")]
        public int PrimaryAliasType { get; set; }

        [JsonProperty("auth_methods")]
        public List<string> AuthMethods { get; set; }

        [JsonProperty("preferred_auth_method")]
        public string PreferredAuthMethod { get; set; }

        [JsonProperty("csrf_token")]
        public string CsrfToken { get; set; }
    }
}