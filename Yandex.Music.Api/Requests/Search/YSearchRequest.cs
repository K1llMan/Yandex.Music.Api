using System.Collections.Generic;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Search
{
    internal class YSearchRequest : YRequest
    {
        public YSearchRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create(string searchText, YSearchType searchType, int page = 0)
        {
            var query = new Dictionary<string, string> {
                {"text", searchText},
                {"type", searchType.ToString()},
                {"page", page.ToString()},
            };

            FormRequest($"{YEndpoints.API}/search", query: query);

            return this;
        }
    }
}