using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Auth
{
    internal class YGetAuthInfoRequest : YRequest
    {
        public YGetAuthInfoRequest(AuthStorage storage) : base(storage)
        {
        }

        public YRequest Create()
        {
            FormRequest($"{YEndpoints.API}/account/status");

            return this;
        }
    }
}