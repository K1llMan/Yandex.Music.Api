using System.Runtime.Serialization;

namespace Yandex.Music.Api.Models.Account
{
    public enum YAuthCaptchaErrorCode
    {
        [EnumMember(Value = "missingvalue")]
        MissingValue,
        [EnumMember(Value = "captchalocate")]
        CaptchaLocate,
        [EnumMember(Value = "incorrect")]
        Incorrect
    }
}
