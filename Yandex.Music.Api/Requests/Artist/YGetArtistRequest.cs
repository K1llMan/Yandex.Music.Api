using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Album
{
    internal class YGetArtistRequest : YRequest
    {
        public YGetArtistRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create(string artistId)
        {
            FormRequest($"{YEndpoints.API}/artists/{artistId}/brief-info");

            return this;
        }
    }
}