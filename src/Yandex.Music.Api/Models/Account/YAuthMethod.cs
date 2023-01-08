using System.Runtime.Serialization;

namespace Yandex.Music.Api.Models.Account
{
    public enum YAuthMethod
    {
        Password,
        [EnumMember(Value = "magic_x_token")]
        MagicToken
    }
}