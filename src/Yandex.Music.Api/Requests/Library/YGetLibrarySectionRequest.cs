using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Library;

namespace Yandex.Music.Api.Requests.Library
{
    internal class YGetLibrarySectionRequest<T> : YRequest<YResponse<T>>
    {
        public YGetLibrarySectionRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest<YResponse<T>> Create(YLibrarySection section, YLibrarySectionType type = YLibrarySectionType.Likes)
        {
            FormRequest($"{YEndpoints.API}/users/{storage.User.Uid}/{type.ToString().ToLower()}/{section.ToString().ToLower()}");

            return this;
        }
    }
}