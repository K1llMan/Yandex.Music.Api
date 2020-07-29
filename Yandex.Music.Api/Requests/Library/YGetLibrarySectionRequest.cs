using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Library;

namespace Yandex.Music.Api.Requests.Library
{
    internal class YGetLibrarySectionRequest : YRequest
    {
        public YGetLibrarySectionRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest Create(YLibrarySection section, YLibrarySectionType type = YLibrarySectionType.Likes)
        {
            FormRequest($"{YEndpoints.API}/users/{storage.User.Uid}/{type.ToString().ToLower()}/{section.ToString().ToLower()}");

            return this;
        }
    }
}