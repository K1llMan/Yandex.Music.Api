using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Account
{
    public class YAuthBase
    {
        public YAuthStatus Status { get; set; }

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }

        public List<YAuthError> Errors { get; set; }
    }
}
