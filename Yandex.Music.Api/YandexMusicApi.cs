using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.API;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests;
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

        #region Вспомогательные функции

        protected internal T Deserialize<T>(JToken token, string jsonPath = "")
        {
            JToken obj = token.SelectToken(jsonPath).ToString();
            return JsonConvert.DeserializeObject<T>(obj.ToString());
        }

        protected internal T Deserialize<T>(string json, string jsonPath = "")
        {
            return Deserialize<T>(JToken.Parse(json), jsonPath);
        }

        protected internal async Task<T> GetDataFromResponseAsync<T>(HttpContext context, HttpWebResponse response, string jsonPath = "")
        {
            try {
                string result;
                using (var stream = response.GetResponseStream()) {
                    var reader = new StreamReader(stream);
                    result = await reader.ReadToEndAsync();
                }

                context.Cookies.Add(response.Cookies);
                return Deserialize<T>(result, jsonPath);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                throw;
            }
        }

        #endregion Вспомогательные функции

        #region Основные функции

        public async Task<YGetCookieResponse> GetYandexCookieAsync(YAuthStorage storage)
        {
            var request = new YGetCookieRequest(storage.Context).Create(storage.User.Login);
            //        request.ProtocolVersion = new Version(2, 0);
            //        request.Headers.Add(":method", "GET");
            //        request.Headers.Add(":authority", "matchid.adfox.yandex.ru");
            //        request.Headers.Add(":path", "/getcookie");
            //        request.Headers.Add(":scheme", "https");
            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await GetDataFromResponseAsync<YGetCookieResponse>(storage.Context, response);
            }
        }

        public YGetCookieResponse GetYandexCookie(YAuthStorage storage)
        {
            return GetYandexCookieAsync(storage).GetAwaiter().GetResult();
        }

        public YandexMusicApi UseWebProxy(IWebProxy proxy)
        {
            this.proxy = proxy;

            return this;
        }

        public YandexMusicApi()
        {
            AccountsApi = new YAccountsAPI(this);
            AlbumAPI = new YAlbumAPI(this);
            LibraryAPI = new YLibraryAPI(this);
            PlaylistAPI = new YPlaylistAPI(this);
            SearchAPI = new YSearchAPI(this);
            TrackAPI = new YTrackAPI(this);
            UserAPI = new YUserAPI(this);
        }

        #endregion Основные функции
    }
}