using System.Collections.Generic;
using System.Linq;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YStorageDownloadFileRequest : YRequest
    {
        public YStorageDownloadFileRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest Create(string src)
        {
            
            var query = new Dictionary<string, string> {
                {"format", "json"}
            };

            
            var parts = src.Split('?');
            parts[1].Split('&').ToList().ForEach(p => {
                var param = p.Split('=');
                query.Add(param[0], param[1]);
            });

            FormRequest(parts[0], query: query);

            return this;
        }
    }
}