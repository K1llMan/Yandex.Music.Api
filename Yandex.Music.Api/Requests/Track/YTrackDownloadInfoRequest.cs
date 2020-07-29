using System.Collections.Generic;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YTrackDownloadInfoRequest : YRequest
    {
        public YTrackDownloadInfoRequest(YandexMusicApi yandex, AuthStorage storage) : base(yandex, storage)
        {
        }

        public YRequest Create(string trackKey, bool direct)
        {
            Dictionary<string, string> query = new Dictionary<string, string> {
                { "direct", direct.ToString() }
            };

            FormRequest($"{YEndpoints.API}/tracks/{trackKey}/download-info", query: query);

            return this;
        }
    }
}