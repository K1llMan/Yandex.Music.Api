using System.Net;
using System.Text;
using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Search
{
    internal class YSearchRequest : YRequest
    {
        public YSearchRequest(HttpContext context) : base(context)
        {
        }

        public HttpWebRequest Create(string searchText, YandexSearchType searchType, int page = 0)
        {
            var searchTypeAsString = searchType.ToString();
            var urlSearch = new StringBuilder();
            urlSearch.Append($"https://music.yandex.ru/handlers/music-search.jsx?text={searchText}");
            urlSearch.Append($"&type={searchTypeAsString}");
            urlSearch.Append(
                $"&page={page}&ncrnd=0.7060701951464323&lang=ru&external-domain=music.yandex.ru&overembed=false");

            var url = urlSearch.ToString();
            var request = GetRequest(url, WebRequestMethods.Http.Get);

            return request;
        }
    }
}