using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Requests.Auth
{
    internal class YGetAuthInfoRequest : YRequest<YResponse<YAccountResult>>
    {
        public YGetAuthInfoRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest<YResponse<YAccountResult>> Create()
        {
            FormRequest($"{YEndpoints.API}/account/status");

            return this;
        }
    }
}