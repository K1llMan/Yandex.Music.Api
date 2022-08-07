using System.Collections.Generic;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YTrackDownloadInfoRequest : YRequest<YResponse<List<YTrackDownloadInfo>>>
    {
        public YTrackDownloadInfoRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest<YResponse<List<YTrackDownloadInfo>>> Create(string trackKey, bool direct)
        {
            Dictionary<string, string> query = new()
            {
                { "direct", direct.ToString() }
            };

            FormRequest($"{YEndpoints.API}/tracks/{trackKey}/download-info", query: query);

            return this;
        }
    }
}