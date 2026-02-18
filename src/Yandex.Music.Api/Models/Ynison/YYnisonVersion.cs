using System;

namespace Yandex.Music.Api.Models.Ynison
{
    public class YYnisonVersion
    {
        public string DeviceId { get; set; }
        public string Version { get; set; } = Math.Floor(0x8000000000000000 * new Random().NextDouble()).ToString("##############################") + "0";
        public decimal TimestampMs { get; set; } = DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }
}
