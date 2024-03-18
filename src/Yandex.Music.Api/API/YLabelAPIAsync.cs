using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Label;

namespace Yandex.Music.Api.API
{
    public partial class YLabelAPI : YCommonAPI
    {
        public YLabelAPI(YandexMusicApi yandex) : base(yandex)
        {
        }

        /// <summary>
        /// Постраничное получение альбомов лейбла
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="label">Лейбл</param>
        /// <param name="page">Страница</param>
        /// <returns></returns>
        public YResponse<YLabelAlbums> GetAlbumsByLabel(AuthStorage storage, YLabel label, int page)
        {
            return GetAlbumsByLabelAsync(storage, label, page).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Постраничное получение артистов лейбла
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="label">Лейбл</param>
        /// <param name="page">Страница</param>
        /// <returns></returns>
        public YResponse<YLabelArtists> GetArtistsByLabel(AuthStorage storage, YLabel label, int page)
        {
            return GetArtistsByLabelAsync(storage, label, page).GetAwaiter().GetResult();
        }
    }
}