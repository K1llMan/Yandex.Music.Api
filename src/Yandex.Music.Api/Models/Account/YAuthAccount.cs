using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account;

public class YDisplayName
{
    [JsonProperty("default_avatar")]
    public string DefaultAvatar { get; set; }
    public string Name { get; set; }
}

public class YPerson
{
    public string Country { get; set; }
    public string Firstname { get; set; }
    public int Gender { get; set; }
    public string Language { get; set; }
    public string Lastname { get; set; }
}

public class YAuthAccount
{
    [JsonProperty("avatar_url")]
    public string AvatarUrl { get; set; }
    [JsonProperty("display_login")]
    public string DisplayLogin { get; set; }
    [JsonProperty("display_name")]
    public YDisplayName DisplayName { get; set; }
    [JsonProperty("has_master")]
    public bool HasMaster { get; set; }
    [JsonProperty("has_secure_phone")]
    public bool HasSecurePhone { get; set; }
    [JsonProperty("is_2fa_enabled")]
    public bool Is2faEnabled { get; set; }
    [JsonProperty("is_rfc_2fa_enabled")]
    public bool IsRfc2faEnabled { get; set; }
    [JsonProperty("is_sms_2fa_enabled")]
    public bool IsSms2faEnabled { get; set; }
    [JsonProperty("is_workspace_user")]
    public bool IsWorkspaceUser { get; set; }
    [JsonProperty("is_yandexoid")]
    public bool IsYandexoid { get; set; }
    [JsonProperty("login")]
    public bool Login { get; set; }
    
    public YPerson Person { get; set; }
    [JsonProperty("secure_phone_id")]
    public int SecurePhoneId { get; set; }
    public int Uid { get; set; }
}