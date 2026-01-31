using System.Collections.Generic;

using Newtonsoft.Json;
using Yandex.Music.Api.Models.Pins.Items;

namespace Yandex.Music.Api.Models.Pins
{
    public class YPins
    {
        [JsonConverter(typeof(YPinConverter))]
        public List<YPin> Pins { get; set; }
    }
}