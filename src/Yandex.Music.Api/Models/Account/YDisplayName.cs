using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account;

public class YDisplayName
{
    [JsonProperty("default_avatar")]
    public string DefaultAvatar { get; set; }

    public string Name { get; set; }
}