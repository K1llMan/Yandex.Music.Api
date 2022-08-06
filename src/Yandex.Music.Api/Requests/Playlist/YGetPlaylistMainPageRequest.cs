using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Landing;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YGetPlaylistMainPageRequest : YRequest<YResponse<YLanding>>
    {
        public YGetPlaylistMainPageRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest<YResponse<YLanding>> Create()
        {
            FormRequest($"{YEndpoints.API}/landing3?blocks=personalplaylists");

            return this;
        }
    }
}