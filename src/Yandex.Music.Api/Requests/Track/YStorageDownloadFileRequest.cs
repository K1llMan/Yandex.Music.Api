using System.Collections.Generic;
using System.Linq;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YStorageDownloadFileRequest : YRequest<YStorageDownloadFile>
    {
        public YStorageDownloadFileRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest<YStorageDownloadFile> Create(string src)
        {
            Dictionary<string, string> query = new()
            {
                {"format", "json"}
            };

            string[] parts = src.Split('?');
            parts[1].Split('&').ToList().ForEach(p => {
                string[] param = p.Split('=');
                query.Add(param[0], param[1]);
            });

            FormRequest(parts[0], query: query);

            return this;
        }
    }
}