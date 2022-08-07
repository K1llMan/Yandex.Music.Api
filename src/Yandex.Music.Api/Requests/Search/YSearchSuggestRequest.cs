using System.Collections.Generic;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Search;

namespace Yandex.Music.Api.Requests.Search
{
    internal class YSearchSuggestRequest : YRequest<YResponse<YSearchSuggest>>
    {
        public YSearchSuggestRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest<YResponse<YSearchSuggest>> Create(string searchText)
        {
            Dictionary<string, string> query = new()
            {
                { "part", searchText }
            };

            FormRequest($"{YEndpoints.API}/search/suggest", query: query);

            return this;
        }
    }
}