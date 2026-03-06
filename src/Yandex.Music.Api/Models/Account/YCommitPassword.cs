using Newtonsoft.Json;
using Yandex.Music.Api.Models.Account;

namespace Yandex.Music.Api.API;

public class YCommitPassword: YAuthBase
{
    public string State { get; set; }
    [JsonProperty("avatarId")]
    public string AvatarId { get; set; }
    public YAuthAccount Account { get; set; }
}