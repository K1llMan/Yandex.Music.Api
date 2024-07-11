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

        /*
         * Could not find member 'location_id' on object of type 'YShortAccountInfo'.
         * Path 'location_id', line 1, position 94.
         */
        [JsonProperty("location_id")]
        public int LocationId { get; set; }

        /*
         * Could not find member 'gender' on object of type 'YShortAccountInfo'.
         * Path 'gender', line 1, position 329.
         */
        [JsonProperty("gender")]
        public string Gender { get; set; }

        /*
         * Could not find member 'is_avatar_empty' on object of type 'YShortAccountInfo'.
         * Path 'is_avatar_empty', line 1, position 351.
         */
        [JsonProperty("is_avatar_empty")]
        public bool IsAvatarEmpty { get; set; }

        /*
         * Could not find member 'machine_readable_login' on object of type 'YShortAccountInfo'.
         * Path 'machine_readable_login', line 1, position 544.
         */
        [JsonProperty("machine_readable_login")]
        public string MachineReadableLogin { get; set; }

        /*
         * Could not find member 'has_cards' on object of type 'YShortAccountInfo'.
         * Path 'has_cards', line 1, position 569.
         */
        [JsonProperty("has_cards")]
        public bool HasCards { get; set; }

        /*
         * Could not find member 'has_family' on object of type 'YShortAccountInfo'.
         * Path 'has_family', line 1, position 588.
         */
        [JsonProperty("has_family")]
        public bool HasFamily { get; set; }

        /*
         * Could not find member 'x_token_client_id' on object of type 'YShortAccountInfo'.
         * Path 'x_token_client_id', line 1, position 644.
         */
        [JsonProperty("x_token_client_id")]
        public string XTokenClientId { get; set; }

        /*
         * Could not find member 'x_token_need_reset' on object of type 'YShortAccountInfo'.
         * Path 'x_token_need_reset', line 1, position 700.
         */
        [JsonProperty("x_token_need_reset")]
        public bool XTokenNeedReset {  get; set; }
    }
}
