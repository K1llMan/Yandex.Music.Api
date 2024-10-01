using System.Collections.Generic;
using Yandex.Music.Api.Models.Ynison.Messages;

namespace Yandex.Music.Api.Models.Ynison
{
    public class YYnisonState: YYnisonMessage
    {
        public List<YYnisonDeviceFull> Devices { get; set; }
        public YYnisonPlayerState PlayerState { get; set; }
        public decimal TimestampMs { get; set; }
    }
}