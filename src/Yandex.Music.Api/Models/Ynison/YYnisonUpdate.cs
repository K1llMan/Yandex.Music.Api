using System;

namespace Yandex.Music.Api.Models.Ynison
{
    public class YYnisonUpdate
    {
        #warning нужен enum
        public string ActivityInterceptionType { get; set; } = "DO_NOT_INTERCEPT_BY_DEFAULT";

        public decimal PlayerActionTimestampMs { get; set; } = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        public string Rid { get; set; } = Guid.NewGuid().ToString();
    }
}