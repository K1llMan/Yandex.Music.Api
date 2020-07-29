using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Album
{
    internal class YGetAlbumRequest : YRequest
    {
        public YGetAlbumRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest Create(string albumId)
        {
            FormRequest($"{YEndpoints.API}/albums/{albumId}/with-tracks");

            return this;
        }
    }
}