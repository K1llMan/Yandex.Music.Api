using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Passport;

public class YMasterInfo
{
    [JsonProperty("firstname")]
    public string FirstName { get; set; }

    [JsonProperty("lastname")] 
    public string LastName { get; set; }
}