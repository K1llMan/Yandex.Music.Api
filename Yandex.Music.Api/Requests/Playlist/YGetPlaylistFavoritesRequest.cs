using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YGetPlaylistFavoritesRequest : YRequest
    {
        public YGetPlaylistFavoritesRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create()
        {
            FormRequest($"{YEndpoints.API}/users/{storage.User.Uid}/playlists/list");

            return this;
        }
    }
}