using System.Collections.Generic;

namespace Yandex.Music.Api.Models.Search
{
    public class YSearchResult<T>
    {
        public List<T> Items { get; set; }
        public int? Total { get; set; }
        public int? PerPage { get; set; }
        public int? Order { get; set; }
    }
}