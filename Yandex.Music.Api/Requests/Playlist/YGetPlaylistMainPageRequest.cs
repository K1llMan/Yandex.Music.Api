using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YGetPlaylistMainPageRequest : YRequest
    {
        public YGetPlaylistMainPageRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest Create()
        {
            FormRequest($"{YEndpoints.API}/landing3?blocks=personalplaylists");

            return this;
        }
    }
}