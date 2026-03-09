using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account;

public class YCommitPassword: YAuthBase
{
    public string State { get; set; }
    [JsonProperty("avatarId")]
    public string AvatarId { get; set; }
    public YAuthAccount Account { get; set; }
}