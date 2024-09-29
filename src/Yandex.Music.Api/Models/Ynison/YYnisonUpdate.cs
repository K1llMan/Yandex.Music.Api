using System;

using Newtonsoft.Json;

namespace Yandex.Music.Api.Models.Ynison
{
    public class YYnisonUpdate
    {
        [JsonProperty("activity_interception_type")]
        public string ActivityInterceptionType { get; set; } = "DO_NOT_INTERCEPT_BY_DEFAULT";

        [JsonProperty("player_action_timestamp_ms")]
        public decimal PlayerActionTimestampMs { get; set; } = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        public string Rid { get; set; } = new Guid().ToString();
    }
}