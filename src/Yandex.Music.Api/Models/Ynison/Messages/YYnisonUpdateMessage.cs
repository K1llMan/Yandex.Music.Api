using System;

namespace Yandex.Music.Api.Models.Ynison.Messages
{
    public class YYnisonUpdateMessage : YYnisonMessage
    {
#warning нужен enum
        public string ActivityInterceptionType { get; set; } = "DO_NOT_INTERCEPT_BY_DEFAULT";

        public decimal PlayerActionTimestampMs { get; set; } = DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }
}
