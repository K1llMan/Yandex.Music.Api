using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account;

public class YMasterMember
{
    [JsonProperty("uid")]
    public int Uid { get; set; }
    
    [JsonProperty("display_login")]
    public string DisplayLogin { get; set; }

    [JsonProperty("public_name")]
    public string PublicName { get; set; }

    [JsonProperty("avatar_url")]
    public string AvatarUrl { get; set; }

    [JsonProperty("has_plus")] 
    public bool HasPlus { get; set; }

    [JsonProperty("Secure_phone_number")]
    public string SecurePhoneNumber { get; set; }

    [JsonProperty("primary_alias_type")] 
    public int PrimaryAliasType { get; set; }
}