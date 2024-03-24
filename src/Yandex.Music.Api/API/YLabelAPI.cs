using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Label;
using Yandex.Music.Api.Requests.Label;

namespace Yandex.Music.Api.API
{
    public partial class YLabelAPI : YCommonAPI
    {
        /// <summary>
        /// Постраничное получение альбомов лейбла
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="label">Лейбл</param>
        /// <param name="page">Страница</param>
        /// <returns></returns>
        public Task<YResponse<YLabelAlbums>> GetAlbumsByLabelAsync(AuthStorage storage, YLabel label, int page)
        {
            return new YGetLabelAlbumsBuilder(api, storage)
                .Build((label, page))
                .GetResponseAsync();
        }

        /// <summary>
        /// Постраничное получение артистов лейбла
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="label">Лейбл</param>
        /// <param name="page">Страница</param>
        /// <returns></returns>
        public Task<YResponse<YLabelArtists>> GetArtistsByLabelAsync(AuthStorage storage, YLabel label, int page)
        {
            return new YGetLabelArtistsBuilder(api, storage)
                .Build((label, page))
                .GetResponseAsync();
        }
    }
}