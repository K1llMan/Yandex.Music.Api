using System.Runtime.Serialization;

namespace Yandex.Music.Api.Models.Account
{
    public enum YAuthMethod
    {
        Password,
        [EnumMember(Value = "magic_x_token")]
        MagicToken,
        [EnumMember(Value = "magic_x_token_with_pictures")]
        MagicTokenWithPictures,
        [EnumMember(Value = "magic_link")]
        MagicLink,
        Magic,
        Otp,
        [EnumMember(Value = "social_gg")]
        Social,
        WebAuthN,
        [EnumMember(Value = "sms_code")]
        SmsCode
    }
}
