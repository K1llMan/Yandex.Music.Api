using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Playlist;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YGetPlaylistRequest : YRequest
    {
        public YGetPlaylistRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest Create(string user, string kind)
        {
            FormRequest($"{YEndpoints.API}/users/{user}/playlists/{kind}");

            return this;
        }

        public YRequest Create(YPlaylist playlist)
        {
            FormRequest($"{YEndpoints.API}/users/{playlist.Owner.Uid}/playlists/{playlist.Kind}");

            return this;
        }
    }
}