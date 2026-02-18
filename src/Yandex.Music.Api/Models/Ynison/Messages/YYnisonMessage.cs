using System;

namespace Yandex.Music.Api.Models.Ynison.Messages
{
    public class YYnisonMessage
    {
        public string Rid { get; set; } = Guid.NewGuid().ToString();
    }
}
