using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Passport;

public abstract class PassportResponseBase
{
    [JsonProperty("error")]
    public string Error { get; set; }

    [JsonProperty("errors")]
    public List<string> Errors { get; set; }
}