using System.Runtime.Serialization;

namespace Yandex.Music.Api.Models.Ynison
{
    public enum YYnisonEntityType
    {
        [EnumMember(Value = "VARIOUS")]
        Various,

        [EnumMember(Value = "RADIO")]
        Radio
    }
}