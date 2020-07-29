using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Auth
{
    internal class YGetAuthInfoRequest : YRequest
    {
        public YGetAuthInfoRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest Create()
        {
            FormRequest($"{YEndpoints.API}/account/status");

            return this;
        }
    }
}