using System.Net;
using System.Threading.Tasks;

using Yandex.Music.Api.API;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests.Yandex;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api
{
    public class YandexMusicApi
    {
        #region Поля

        private IWebProxy proxy;

        #endregion Поля

        #region Ветки API

        /// <summary>
        ///     AccountsApi
        /// </summary>
        public YAccountsAPI AccountsApi { get; set; }

        /// <summary>
        ///     AlbumAPI
        /// </summary>
        public YAlbumAPI AlbumAPI { get; set; }

        /// <summary>
        ///     LibraryAPI
        /// </summary>
        public YLibraryAPI LibraryAPI { get; set; }

        /// <summary>
        ///     PlaylistAPI
        /// </summary>
        public YPlaylistAPI PlaylistAPI { get; set; }

        /// <summary>
        ///     SearchAPI
        /// </summary>
        public YSearchAPI SearchAPI { get; set; }

        /// <summary>
        ///     TrackAPI
        /// </summary>
        public YTrackAPI TrackAPI { get; set; }

        /// <summary>
        ///     UserAPI
        /// </summary>
        public YUserAPI UserAPI { get; set; }

        #endregion Ветки API

        #region Основные функции

        public async Task<YGetCookieResponse> GetYandexCookieAsync(YAuthStorage storage)
        {
            return await new YGetCookieRequest(storage)
                .Create(storage.User.Login)
                .GetResponseAsync<YGetCookieResponse>();
        }

        public YGetCookieResponse GetYandexCookie(YAuthStorage storage)
        {
            return GetYandexCookieAsync(storage).GetAwaiter().GetResult();
        }

        public YandexMusicApi UseWebProxy(IWebProxy usingProxy)
        {
            proxy = usingProxy;

            return this;
        }

        public YandexMusicApi()
        {
            AccountsApi = new YAccountsAPI();
            AlbumAPI = new YAlbumAPI();
            LibraryAPI = new YLibraryAPI();
            PlaylistAPI = new YPlaylistAPI();
            SearchAPI = new YSearchAPI();
            TrackAPI = new YTrackAPI();
            UserAPI = new YUserAPI();
        }

        #endregion Основные функции
    }
}