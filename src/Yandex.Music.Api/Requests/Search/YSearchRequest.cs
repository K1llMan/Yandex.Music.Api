using System.Collections.Generic;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Search;

namespace Yandex.Music.Api.Requests.Search
{
    internal class YSearchRequest : YRequest<YResponse<YSearch>>
    {
        public YSearchRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest<YResponse<YSearch>> Create(string searchText, YSearchType searchType, int page = 0)
        {
            Dictionary<string, string> query = new()
            {
                {"text", searchText},
                {"type", searchType.ToString()},
                {"page", page.ToString()}
            };

            FormRequest($"{YEndpoints.API}/search", query: query);

            return this;
        }
    }
}