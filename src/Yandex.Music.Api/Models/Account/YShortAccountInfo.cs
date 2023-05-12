using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account
{
    public class YShortAccountInfo : YAuthBase
    {
        [JsonProperty("public_id")]
        public string PublicId { get; set; }

        public string Uid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Birthday { get; set; }

        [JsonProperty("has_password")]
        public bool HasPassword { get; set; }

        public List<string> Partitions { get; set; }

        [JsonProperty("primary_alias_type")]
        public int PrimaryAliasType { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("normalized_display_login")]
        public string NormalizedDisplayLogin { get; set; }

        [JsonProperty("x_token_issued_at")]
        public int XTokenIssuedAt { get; set; }

        [JsonProperty("display_login")]
        public string DisplayLogin { get; set; }

        [JsonProperty("public_name")]
        public string PublicName { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("native_default_email")]
        public string NativeDefaultEmail { get; set; }

        [JsonProperty("has_plus")]
        public bool HasPlus { get; set; }
    }
}