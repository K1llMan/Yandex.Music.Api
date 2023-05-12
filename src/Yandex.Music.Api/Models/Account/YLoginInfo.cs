using System.Collections.Generic;

using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account
{
    public class YLoginInfo
    {
        public string Id { get; set; }
        public string Login { get; set; }
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("real_name")]
        public string RealName { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        public string Sex { get; set; }
        [JsonProperty("default_email")]
        public string DefaultEmail { get; set; }
        public List<string> Emails { get; set; }
        public string Birthday { get; set; }
        [JsonProperty("default_avatar_id")]
        public string DefaultAvatarId { get; set; }

        public string AvatarUrl => $"https://avatars.mds.yandex.net/get-yapic/{DefaultAvatarId}/islands-200";
        [JsonProperty("is_avatar_empty")]
        public bool IsAvatarEmpty { get; set; }
        public string PsuId { get; set; }

    }
}