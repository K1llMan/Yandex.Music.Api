using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Models.Search;
using Yandex.Music.Api.Models.Search.Album;
using Yandex.Music.Api.Models.Search.Artist;
using Yandex.Music.Api.Models.Search.Playlist;
using Yandex.Music.Api.Models.Search.Track;
using Yandex.Music.Api.Models.Search.User;
using Yandex.Music.Api.Models.Search.Video;

namespace Yandex.Music.Api.Responses
{
    public class YSearchResponse
    {
        public string Text { get; set; }
        public YSearchResult<YSearchAlbumModel> Albums { get; set; }
        public YSearchResult<YSearchTrackModel> Tracks { get; set; }
        public YSearchResult<YSearchArtistModel> Artists { get; set; }
        
        public YSearchResult<YSearchVideoModel> Videos { get; set; }
        public YSearchResult<YSearchPlaylistModel> Playlists { get; set; }
        public YSearchResult<YSearchUserModel> Users { get; set; }
        
        public string RequestId { get; set; }
        public string SearchRequestId { get; set; }
//        extendedParams
//        public misspell
        
        public YSearchPager Pager { get; set; }
        public YSearchCounter Counts { get; set; }

        internal static YSearchResponse FromJson(JToken json)
        {
            if (json == null)
            {
                return null;
            }

            return new YSearchResponse
            {
                Text = json.SelectToken("text")?.ToObject<string>(),
                
                Albums = new YSearchResult<YSearchAlbumModel>
                {
                    Items = json.SelectToken("albums")?.SelectToken("items")?.Select(YSearchAlbumModel.FromJson).ToList(),
                    Order = json.SelectToken("albums")?.SelectToken("order")?.ToObject<int>(),
                    PerPage = json.SelectToken("albums")?.SelectToken("perPage")?.ToObject<int>(),
                    Total = json.SelectToken("albums")?.SelectToken("total")?.ToObject<int>()
                },
                Tracks = new YSearchResult<YSearchTrackModel>
                {
                    Items = json.SelectToken("tracks")?.SelectToken("items")?.Select(YSearchTrackModel.FromJson).ToList(),
                    Order = json.SelectToken("tracks")?.SelectToken("order")?.ToObject<int>(),
                    PerPage = json.SelectToken("tracks")?.SelectToken("perPage")?.ToObject<int>(),
                    Total = json.SelectToken("tracks")?.SelectToken("total")?.ToObject<int>()
                },
                Artists = new YSearchResult<YSearchArtistModel>
                {
                    Items = json.SelectToken("artists")?.SelectToken("items")?.Select(YSearchArtistModel.FromJson).ToList(),
                    Order = json.SelectToken("artists")?.SelectToken("order")?.ToObject<int>(),
                    PerPage = json.SelectToken("artists")?.SelectToken("perPage")?.ToObject<int>(),
                    Total = json.SelectToken("artists")?.SelectToken("total")?.ToObject<int>()
                },
                Playlists = new YSearchResult<YSearchPlaylistModel>
                {
                    Items = json.SelectToken("playlists")?.SelectToken("items")?.Select(YSearchPlaylistModel.FromJson).ToList(),
                    Order = json.SelectToken("playlists")?.SelectToken("order")?.ToObject<int>(),
                    PerPage = json.SelectToken("playlists")?.SelectToken("perPage")?.ToObject<int>(),
                    Total = json.SelectToken("playlists")?.SelectToken("total")?.ToObject<int>()
                },
                // videos
                // users
                RequestId = json.SelectToken("request_id")?.ToObject<string>(),
                SearchRequestId = json.SelectToken("searchRequestId")?.ToObject<string>(),
                Pager = YSearchPager.FromJson(json.SelectToken("pager")),
                Counts = YSearchCounter.FromJson(json.SelectToken("counts"))
            };
        }
    }
}