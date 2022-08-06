using System.Net;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Playlist
{
    internal class YPlaylistRemoveRequest : YRequest<HttpWebResponse>
    {
        public YPlaylistRemoveRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest<HttpWebResponse> Create(string kinds)
        {
            FormRequest($"{YEndpoints.API}/users/{storage.User.Uid}/playlists/{kinds}/delete", method: WebRequestMethods.Http.Post);

            return this;
        }
    }
}