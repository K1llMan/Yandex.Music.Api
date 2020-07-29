using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Album
{
    internal class YGetArtistRequest : YRequest
    {
        public YGetArtistRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest Create(string artistId)
        {
            FormRequest($"{YEndpoints.API}/artists/{artistId}/brief-info");

            return this;
        }
    }
}