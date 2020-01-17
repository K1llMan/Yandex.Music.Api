using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Models.Search
{
    public class YSearchPager
    {
        public int? Total { get; set; }
        public int? PerPage { get; set; }
        public int? Page { get; set; }

        internal static YSearchPager FromJson(JToken json)
        {
            if (json == null)
            {
                return null;
            }

            return new YSearchPager
            {
                Total = json.SelectToken("total")?.ToObject<int>(),
                PerPage = json.SelectToken("perPage")?.ToObject<int>(),
                Page = json.SelectToken("page")?.ToObject<int>()
            };
        }
    }
}