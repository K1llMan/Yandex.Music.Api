using System.Net;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YPlaylistRemoveRequest : YRequest
    {
        public YPlaylistRemoveRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest Create(string kinds)
        {
            FormRequest($"{YEndpoints.API}/users/{storage.User.Uid}/playlists/{kinds}/delete", method: WebRequestMethods.Http.Post);

            return this;
        }
    }
}