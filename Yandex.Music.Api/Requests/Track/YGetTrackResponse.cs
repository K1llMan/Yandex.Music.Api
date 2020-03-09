using System.Collections.Generic;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YGetTrackResponse : YRequest
    {
        public YGetTrackResponse(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create(string trackId)
        {
            var query = new Dictionary<string, string> {
                {"track", trackId}
            };

            FormRequest(YEndpoints.Track, query: query);

            return this;
        }
    }
}