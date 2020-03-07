using System.Net;
using System.Threading.Tasks;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests.Search;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api.API
{
    public class YSearchAPI
    {
        #region Fields

        private readonly YandexMusicApi api;

        #endregion Fields

        #region Main function

        public async Task<YSearchResponse> TrackAsync(YAuthStorage storage, string trackName, int pageNumber = 0)
        {
            return await SearchAsync(storage, trackName, YandexSearchType.Tracks, pageNumber);
        }

        public YSearchResponse Track(YAuthStorage storage, string trackName, int pageNumber = 0)
        {
            return TrackAsync(storage, trackName, pageNumber).GetAwaiter().GetResult();
        }

        public async Task<YSearchResponse> ArtistAsync(YAuthStorage storage, string artistName, int pageNumber = 0)
        {
            return await SearchAsync(storage, artistName, YandexSearchType.Artists, pageNumber);
        }

        public YSearchResponse Artist(YAuthStorage storage, string artistName, int pageNumber = 0)
        {
            return ArtistAsync(storage, artistName, pageNumber).GetAwaiter().GetResult();
        }

        public async Task<YSearchResponse> PlaylistAsync(YAuthStorage storage, string playlistName, int pageNumber = 0)
        {
            return await SearchAsync(storage, playlistName, YandexSearchType.Playlists, pageNumber);
        }

        public YSearchResponse Playlist(YAuthStorage storage, string playlistName, int pageNumber = 0)
        {
            return PlaylistAsync(storage, playlistName, pageNumber).GetAwaiter().GetResult();
        }

        public async Task<YSearchResponse> AlbumsAsync(YAuthStorage storage, string albumName, int pageNumber = 0)
        {
            return await SearchAsync(storage, albumName, YandexSearchType.Albums, pageNumber);
        }

        public YSearchResponse Albums(YAuthStorage storage, string albumName, int pageNumber = 0)
        {
            return AlbumsAsync(storage, albumName, pageNumber).GetAwaiter().GetResult();
        }

        public async Task<YSearchResponse> UsersAsync(YAuthStorage storage, string userName, int pageNumber = 0)
        {
            return await SearchAsync(storage, userName, YandexSearchType.Users, pageNumber);
        }

        public YSearchResponse Users(YAuthStorage storage, string userName, int pageNumber = 0)
        {
            return UsersAsync(storage, userName, pageNumber).GetAwaiter().GetResult();
        }

        public async Task<YSearchResponse> SearchAsync(YAuthStorage storage, string searchText, YandexSearchType searchType, int page = 0)
        {
            var request = new YSearchRequest(storage.Context).Create(searchText, searchType, page);

            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                return await api.GetDataFromResponseAsync<YSearchResponse>(storage.Context, response);
            }
        }

        public YSearchResponse Search(YAuthStorage storage, string searchText, YandexSearchType searchType, int page = 0)
        {
            return SearchAsync(storage, searchText, searchType, page).GetAwaiter().GetResult();
        }

        //    protected YandexTrackDownloadInfo GetDownloadTrackInfo(string storageDir)
        //    {
        //      var fileName = GetDownloadTrackInfoFileName(storageDir);
        //      var request = GetRequest(_settings.GetDownloadTrackInfoURL(storageDir, fileName));
        //      var trackDownloadInfo = new YandexTrackDownloadInfo();

        //      using (var response = (HttpWebResponse) request.GetResponse())
        //      {
        //        using (var stream = response.GetResponseStream())
        //        {
        //          var reader = new StreamReader(stream);
        //          var sourceText = reader.ReadToEnd();

        //          var xElem = XDocument.Parse(sourceText).Root;
        //          var elements = new Dictionary<string, string>();
        //          for (var x = (XElement) xElem.FirstNode; x != null; x = (XElement) x.NextNode)
        //          {
        //            elements.Add(x.Name.LocalName, x.Value);
        //          }
        //          _cookies.Add(response.Cookies);

        //          trackDownloadInfo.Host = elements["host"];
        //          trackDownloadInfo.Path = elements["path"];
        //          trackDownloadInfo.Ts = elements["ts"];
        //          trackDownloadInfo.Region = elements["region"];
        //          trackDownloadInfo.S = elements["s"];
        //        }
        //      }

        //      return trackDownloadInfo;
        //    }

        //    protected string GetDownloadTrackInfoFileName(string storageDir)
        //    {
        //      var url = _settings.GetURLDownloadFile(storageDir);
        //      var request = GetRequest(url, WebRequestMethods.Http.Get);
        //      var fileName = "";
        //      var trackLength = 0;

        //      using (var response = (HttpWebResponse) request.GetResponse())
        //      {
        //        using (var stream = response.GetResponseStream())
        //        {
        //          var reader = new StreamReader(stream);
        //          var sourceText = reader.ReadLine();
        //          sourceText = reader.ReadLine();

        //          var xElem = XDocument.Parse(sourceText).Root;
        //          var attrs = xElem.Attributes()
        //            .Where(a => !a.IsNamespaceDeclaration)
        //            .Select(a => new XAttribute(a.Name.LocalName, a.Value))
        //            .ToList();

        //          _cookies.Add(response.Cookies);
        //          fileName = attrs.First().Value;
        //          trackLength = int.Parse(attrs.Last().Value.ToString());
        //        }
        //      }

        //      return fileName;
        //    }

        public YSearchAPI(YandexMusicApi yandexApi)
        {
            api = yandexApi;
        }

        #endregion Main function
    }
}