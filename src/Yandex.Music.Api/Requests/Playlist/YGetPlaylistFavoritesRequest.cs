using System.Collections.Generic;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Playlist;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YGetPlaylistFavoritesRequest : YRequest<YResponse<List<YPlaylist>>>
    {
        public YGetPlaylistFavoritesRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest<YResponse<List<YPlaylist>>> Create()
        {
            FormRequest($"{YEndpoints.API}/users/{storage.User.Uid}/playlists/list");

            return this;
        }
    }
}