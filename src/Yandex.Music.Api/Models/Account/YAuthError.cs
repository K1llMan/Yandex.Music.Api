using System.Runtime.Serialization;

namespace Yandex.Music.Api.Models.Account
{
    public enum YAuthError
    {
        [EnumMember(Value = "authorization.invalid")]
        AuthorizationInvalid,
        [EnumMember(Value = "sessionid.invalid")]
        SessionIdInvalid,
        [EnumMember(Value = "password.not_matched")]
        PasswordNotMatched,
        [EnumMember(Value = "password.empty")]
        PasswordEmpty,
        [EnumMember(Value = "captcha.required")]
        CaptchaRequired,
        [EnumMember(Value = "captcha.not_matched")]
        CaptchaNotMatched
    }
}
