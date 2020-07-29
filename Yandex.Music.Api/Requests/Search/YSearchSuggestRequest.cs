using System.Collections.Generic;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Search
{
    internal class YSearchSuggestRequest : YRequest
    {
        public YSearchSuggestRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest Create(string searchText)
        {
            var query = new Dictionary<string, string> {
                { "part", searchText }
            };

            FormRequest($"{YEndpoints.API}/search/suggest", query: query);

            return this;
        }
    }
}