using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Album;
using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Requests.Album
{
    internal class YGetAlbumRequest : YRequest<YResponse<YAlbum>>
    {
        public YGetAlbumRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest<YResponse<YAlbum>> Create(string albumId)
        {
            FormRequest($"{YEndpoints.API}/albums/{albumId}/with-tracks");

            return this;
        }
    }
}