using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Yandex.Music.Api.Models.Radio.Restriction
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum YRestrictionType
    {
        [EnumMember(Value = "discrete-scale")]
        DiscreteScale,
        Enum
    }
}
