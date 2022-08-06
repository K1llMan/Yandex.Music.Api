using System.Runtime.Serialization;

namespace Yandex.Music.Api.Models.Common
{
    public enum YTrackSharingFlag
    {
        [EnumMember(Value = "VIDEO_ALLOWED")]
        VideoAllowed,
        [EnumMember(Value = "COVER_ONLY")]
        CoverOnly
    }
}
