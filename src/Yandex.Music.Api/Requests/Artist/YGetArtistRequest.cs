using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Requests.Artist
{
    internal class YGetArtistRequest : YRequest<YResponse<YArtistBriefInfo>>
    {
        public YGetArtistRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest<YResponse<YArtistBriefInfo>> Create(string artistId)
        {
            FormRequest($"{YEndpoints.API}/artists/{artistId}/brief-info");

            return this;
        }
    }
}