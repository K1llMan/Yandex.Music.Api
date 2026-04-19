using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Passport
{
    public abstract class YPassportResponseBase
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("errors")]
        public List<string> Errors { get; set; }

        public bool IsValid() =>
            string.IsNullOrEmpty(Error) || Errors?.Count == 0;
    }
}