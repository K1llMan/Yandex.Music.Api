using Newtonsoft.Json;
using System.Collections.Generic;

using Yandex.Music.Api.Models.Account;

namespace Yandex.Music.Api.Models.Passport
{
    public class YSuggestAccount
    {
        [JsonProperty("allowed_auth_flows")]
        public List<string> AllowedAuthFlows { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("default_avatar")]
        public string DefaultAvatar { get; set; }

        [JsonProperty("display_name")]
        public YDisplayName DisplayName { get; set; }

        [JsonProperty("has_bank_card")]
        public bool HasBankCard { get; set; }

        [JsonProperty("has_family")]
        public bool HasFamily { get; set; }

        [JsonProperty("has_master")]
        public bool HasMaster { get; set; }

        [JsonProperty("has_plus")]
        public bool HasPlus { get; set; }

        [JsonProperty("is_communal")]
        public bool IsCommunal { get; set; }

        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("primary_alias_type")]
        public int PrimaryAliasType { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; }

        [JsonProperty("uid")]
        public long Uid { get; set; }

        [JsonProperty("shields")]
        public List<string> Shields { get; set; }

        [JsonProperty("require_additional_sms_to_login")]
        public bool RequireAdditionalSmsToLogin { get; set; }
    }
}